using Microsoft.AspNetCore.Razor.TagHelpers;

namespace RenderingTagHelperInsideAnother.TagHelpers
{
    public class InnerTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "p";
            output.Attributes.SetAttribute(new TagHelperAttribute("class", "inner-tag-helper"));
            output.Content.SetHtmlContent("This is from the inner tag helper");
        }
    }
}
