using FundosComponents.Models;
using Microsoft.AspNetCore.Mvc;

namespace FundosComponents.Components.ViewComponents;

public class CardInvestimentoViewComponent : ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync(FundoViewModel fundo)
    {
        // Aqui você poderia fazer uma lógica extra, como:
        // if (fundo.Alocado) { /* lógica especial */ }

        return View(fundo); 
        // Por padrão, ele busca a view em: 
        // Views/Shared/Components/CardInvestimento/Default.cshtml
    }
}