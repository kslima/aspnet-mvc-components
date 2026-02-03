namespace FundosComponents.Models;

public class FundoViewModel
{
    public string Nome { get; set; } = string.Empty;
    public string Tipo { get; set; }  = string.Empty;
    public string PerfilRisco { get; set; }  = string.Empty;
    public int NivelRisco { get; set; }
    public decimal AporteMinimo { get; set; }
    public double RentabilidadeMes { get; set; }
    public double RentabilidadeAno { get; set; }
    public double Rentabilidade12M { get; set; }
    public string Classe { get; set; } = string.Empty;
    public string Carencia { get; set; } = string.Empty;
}