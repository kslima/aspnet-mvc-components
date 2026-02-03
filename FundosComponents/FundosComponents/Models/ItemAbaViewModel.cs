namespace FundosComponents.Models;

public class ItemAbaViewModel
{
    public string Titulo { get; set; } = string.Empty;
    public string Action { get; set; } = string.Empty;
    public string Controller { get; set; } = string.Empty;
    public bool EstaAtiva { get; set; }
}