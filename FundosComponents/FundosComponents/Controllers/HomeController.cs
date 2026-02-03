using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FundosComponents.Models;

namespace FundosComponents.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index(string aba = "Fundos")
    {
        
        ViewBag.AbaAtiva = aba;

        // 2. Se a aba for "Fundos", buscamos a lista de fundos
        var listaDeFundos = new List<FundoViewModel>(); 
        if (aba == "Fundos")
        {
            listaDeFundos = ObterListaFundosExemplo(); // Seu método que gera a lista
        }
        
        return View(listaDeFundos);
    }
    
    private List<FundoViewModel> ObterListaFundosExemplo()
    {
        return new List<FundoViewModel>
        {
            new FundoViewModel { 
                Nome = "BRADESCO FICFI MULTIMERCADO MULTIGESTORES PGBL/VGBL", 
                Tipo = "VGBL", NivelRisco = 3, AporteMinimo = 50.00m, 
                RentabilidadeMes = 1.08, RentabilidadeAno = 8.94, Rentabilidade12M = 8.94,
                Classe = "Multimercado", Carencia = "60 dias corridos" 
            },
            new FundoViewModel { 
                Nome = "BRADESCO PRIVATE RENDA FIXA ATIVO SPECIAL", 
                Tipo = "PGBL", NivelRisco = 1, AporteMinimo = 1000.00m, 
                RentabilidadeMes = 0.95, RentabilidadeAno = 11.20, Rentabilidade12M = 12.10,
                Classe = "Renda Fixa", Carencia = "Não há" 
            },
            new FundoViewModel { 
                Nome = "BRADESCO SELEÇÃO DE AÇÕES FIA", 
                Tipo = "VGBL", NivelRisco = 5, AporteMinimo = 100.00m, 
                RentabilidadeMes = -2.40, RentabilidadeAno = 15.30, Rentabilidade12M = 18.50,
                Classe = "Ações", Carencia = "90 dias corridos" 
            },
            new FundoViewModel { 
                Nome = "BRADESCO ESTRATÉGIA DINÂMICA CRÉDITO PRIVADO", 
                Tipo = "VGBL", NivelRisco = 2, AporteMinimo = 500.00m, 
                RentabilidadeMes = 1.15, RentabilidadeAno = 9.80, Rentabilidade12M = 10.50,
                Classe = "Renda Fixa", Carencia = "30 dias corridos" 
            }
        };
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}