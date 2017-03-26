using System;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text.Encodings.Web;
using System.IO;

namespace RenderingTagHelperInsideAnother.TagHelpers
{
    public class WrapperTagHelper : TagHelper
    {
        private HtmlEncoder _encoder;

        public WrapperTagHelper(HtmlEncoder encoder)
        {
            _encoder = encoder;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            
            output.TagName = "div";
            output.Attributes.SetAttribute(new TagHelperAttribute("class", "wrapper-tag-helper"));

            string innerContent = renderInnerTagHelper();

            string finalContent = $@"<p>Wrapper</p>
{innerContent}";

            output.Content.SetHtmlContent(finalContent);
        }

        /*
         * This methods creates, processes and renders the InnerTagHelper
         */
        private string renderInnerTagHelper()
        {
            InnerTagHelper innerTagHelper = new InnerTagHelper();
            var attributes = new TagHelperAttributeList();
            
            // Create a TagHelperOutput instance
            TagHelperOutput innerOutput = new TagHelperOutput(
                tagName: "div",
                attributes: attributes,
                getChildContentAsync: (useCachedResult, encoder) =>
                     Task.Run<TagHelperContent>(() => new DefaultTagHelperContent())
            )
            {
                TagMode = TagMode.StartTagAndEndTag
            };
            // Create a TagHelperContext instance
            TagHelperContext innerContext = new TagHelperContext(
                allAttributes: attributes,
                items: new Dictionary<object, object>(), 
                uniqueId: Guid.NewGuid().ToString()
            );

            // Process the InnerTagHelper instance 
            innerTagHelper.Process(innerContext, innerOutput);
            
            // Render and return the tag helper attributes and content
            return renderTagHelperOutput(innerOutput);
        }

        /*
         * Helper Method to gather the html content
         */
        private string renderTagHelperOutput(TagHelperOutput output)
        {
            using (var writer = new StringWriter())
            {
                output.WriteTo(writer, _encoder);
                return writer.ToString();
            }
        }
        
    }
}
