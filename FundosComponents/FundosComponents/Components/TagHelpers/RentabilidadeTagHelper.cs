using Microsoft.AspNetCore.Razor.TagHelpers;

namespace FundosComponents.Components.TagHelpers;

[HtmlTargetElement("ui-rentability")]
public class RentabilidadeTagHelper : TagHelper {
    public double Valor { get; set; }
    public string Legenda { get; set; } = string.Empty;

    public override void Process(TagHelperContext context, TagHelperOutput output) {
        output.TagName = "span";
        string corClass = Valor >= 0 ? "pos" : "neg";
        string seta = Valor >= 0 ? "↑" : "↓";
        
        output.Attributes.SetAttribute("class", $"rent-badge {corClass}");
        output.Content.SetHtmlContent($"{Legenda}: <strong>{Math.Abs(Valor):N2}% {seta}</strong>");
    }
}