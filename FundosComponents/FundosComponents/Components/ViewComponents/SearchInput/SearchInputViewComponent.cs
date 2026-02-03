using Microsoft.AspNetCore.Mvc;

namespace FundosComponents.Components.ViewComponents.SearchInput;

public class SearchInputViewComponent : ViewComponent
{
    public IViewComponentResult Invoke(SearchInputViewModel model)
    {
        return View(model);
    }
}
