using FundosComponents.Models;
using Microsoft.AspNetCore.Mvc;

namespace FundosComponents.Controllers;

public class PrevidenciaController : Controller
{
    public IActionResult Fundos()
    {
        ViewBag.AbaAtiva = "Fundos";
        return View("Fundos", ObterListaFundosExemplo());
    }

    public IActionResult Rendimentos()
    {
        return View("Rendimentos", new RendimentosViewModel());
    }

    public IActionResult Extratos()
    {
        return View("Extratos", new ExtratoViewModel());
    }
    
    [HttpGet]
    public IActionResult Buscar(string q)
    {
        var resultados = new List<string>
        {
            "Ações",
            "Fundos",
            "Renda Fixa",
            "Tesouro Direto",
            "Previdência",
            "COE"
        };

        return Json(resultados
            .Where(x => x.Contains(q, StringComparison.InvariantCultureIgnoreCase))
            .Take(10));
    }

    private List<FundoViewModel> ObterListaFundosExemplo()
    {
        return
        [
            new FundoViewModel
            {
                Nome = "BRADESCO FICFI MULTIMERCADO MULTIGESTORES PGBL/VGBL",
                Tipo = "VGBL", NivelRisco = 3, AporteMinimo = 50.00m,
                RentabilidadeMes = 1.08, RentabilidadeAno = 8.94, Rentabilidade12M = 8.94,
                Classe = "Multimercado", Carencia = "60 dias corridos"
            },

            new FundoViewModel
            {
                Nome = "BRADESCO PRIVATE RENDA FIXA ATIVO SPECIAL",
                Tipo = "PGBL", NivelRisco = 1, AporteMinimo = 1000.00m,
                RentabilidadeMes = 0.95, RentabilidadeAno = 11.20, Rentabilidade12M = 12.10,
                Classe = "Renda Fixa", Carencia = "Não há"
            },

            new FundoViewModel
            {
                Nome = "BRADESCO SELEÇÃO DE AÇÕES FIA",
                Tipo = "VGBL", NivelRisco = 5, AporteMinimo = 100.00m,
                RentabilidadeMes = -2.40, RentabilidadeAno = 15.30, Rentabilidade12M = 18.50,
                Classe = "Ações", Carencia = "90 dias corridos"
            },

            new FundoViewModel
            {
                Nome = "BRADESCO ESTRATÉGIA DINÂMICA CRÉDITO PRIVADO",
                Tipo = "VGBL", NivelRisco = 2, AporteMinimo = 500.00m,
                RentabilidadeMes = 1.15, RentabilidadeAno = 9.80, Rentabilidade12M = 10.50,
                Classe = "Renda Fixa", Carencia = "30 dias corridos"
            }
        ];
    }
}