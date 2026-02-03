using FundosComponents.Models;
using Microsoft.AspNetCore.Mvc;

namespace FundosComponents.Components.ViewComponents;

public class AbasNavegacaoViewComponent : ViewComponent
{
    public Task<IViewComponentResult> InvokeAsync(string abaAtiva)
    {
        var abas = new List<ItemAbaViewModel>
        {
            new ItemAbaViewModel
            {
                Titulo = "Fundos",
                Action = "Fundos",
                Controller = "Previdencia",
                EstaAtiva = abaAtiva == "Fundos"
            },
            new ItemAbaViewModel
            {
                Titulo = "Meus Planos", 
                Action = "Rendimentos",
                Controller = "Previdencia",
                EstaAtiva = abaAtiva == "Rendimentos"
            },
            new ItemAbaViewModel
            {
                Titulo = "Extratos",
                Action = "Extratos",
                Controller = "Previdencia",
                EstaAtiva = abaAtiva == "Extratos"
            },
            new ItemAbaViewModel
            {
                Titulo = "Dúvidas IOF 2026", 
                Action = "IOF", 
                Controller = "Previdencia",
                EstaAtiva = abaAtiva == "Fundos"
            },
            new ItemAbaViewModel
            {
                Titulo = "Outras Instituições",
                Action = "Outros", 
                Controller = "Previdencia",
                EstaAtiva = abaAtiva == "Fundos"
            }
        };

        // foreach (var aba in abas)
        // {
        //     if (aba.Area.Equals(abaAtiva, StringComparison.OrdinalIgnoreCase))
        //     {
        //         aba.EstaAtiva = true;
        //     }
        // }

        return Task.FromResult<IViewComponentResult>(View(abas));
    }
}