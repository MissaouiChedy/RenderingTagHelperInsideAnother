using System;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace RenderingTagHelperInsideAnother.TagHelpers
{
    public class WrapperTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            
            output.TagName = "div";
            output.Attributes.SetAttribute(new TagHelperAttribute("class", "wrapper-tag-helper"));

            string innerContent = renderInnerTagHelper(context);

            string finalContent = $@"<p>Wrapper</p>
{innerContent}";

            output.Content.SetHtmlContent(finalContent);
        }

        /*
         * This methods creates, processes and renders the InnerTagHelper
         */
        private string renderInnerTagHelper(TagHelperContext context)
        {
            InnerTagHelper innerTagHelper = new InnerTagHelper();

            // Create a TagHelperOutput instance
            TagHelperOutput innerOutput = new TagHelperOutput(
                tagName: "",
                attributes: new TagHelperAttributeList(),
                getChildContentAsync: (useCachedResult, encoder) =>
                     Task.Factory.StartNew<TagHelperContent>(
                            () => new DefaultTagHelperContent()
                     )
            );

            // Process the InnerTagHelper instance 
            innerTagHelper.Process(context, innerOutput);

            // Render and return the tag helper attributes and content
            return $"<{innerOutput.TagName} {renderHtmlAttributes(innerOutput)}>{innerOutput.Content.GetContent()}</{innerOutput.TagName}>";
        }

        /*
         * Helper Method to render html attributes
         */
        private string renderHtmlAttributes(TagHelperOutput output)
        {
            StringBuilder builder = new StringBuilder();
            foreach (var attribute in output.Attributes)
            {
                builder.Append($"{attribute.Name}=\"{attribute.Value}\"");
            }
            return builder.ToString();
        }
        
    }
}
