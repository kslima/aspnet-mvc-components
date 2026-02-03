namespace FundosComponents.Components.ViewComponents.SearchInput;

public class SearchInputViewModel
{
    public string Id { get; set; } = Guid.NewGuid().ToString("N");
    public string Label { get; set; } = "Pesquisar";
    public string Placeholder { get; set; } = "";
    public string Value { get; set; } = string.Empty;
    public string? SearchUrl { get; set; }

    public int MinChars { get; set; } = 2;
}