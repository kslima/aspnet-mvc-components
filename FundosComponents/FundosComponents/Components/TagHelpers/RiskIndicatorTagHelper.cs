namespace FundosComponents.Components.TagHelpers;

using Microsoft.AspNetCore.Razor.TagHelpers;

[HtmlTargetElement("ui-risk-indicator")]
public class RiskIndicatorTagHelper : TagHelper
{
    public int Nivel { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "div";
        output.Attributes.SetAttribute("class", "c-risk-indicator");

        var content = "<span class=\"c-risk-indicator__label\">Risco</span>";
        for (int i = 1; i <= 5; i++)
        {
            var modifier = i <= Nivel ? "active" : "inactive";
            content += $"<span class=\"c-risk-indicator__bar c-risk-indicator__bar--{modifier}\"></span>";
        }

        output.Content.SetHtmlContent(content);
    }
}