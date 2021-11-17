using Microsoft.AspNetCore.Razor.TagHelpers;

namespace SaveFood.TagHelpers
{
    public class MessageTagHelper : TagHelper
    {
        public string Text { get; set; }
        public string Class { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (string.IsNullOrWhiteSpace(Text))
                return;

            output.TagName = "div";
            output.Attributes.SetAttribute("class", string.IsNullOrEmpty(Class) ? "alert alert-success" : Class);
            output.Content.SetHtmlContent($"<button type='button' class='close' data-dismiss='alert'>&times;</button>{Text}");
        }
    }
}
