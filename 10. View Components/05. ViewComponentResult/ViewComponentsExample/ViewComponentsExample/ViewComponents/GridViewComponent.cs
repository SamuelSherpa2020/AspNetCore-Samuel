using Microsoft.AspNetCore.Mvc;
using ViewComponentsExample.Models;

namespace ViewComponentsExample.ViewComponents
{
    //[ViewComponent] the attribute is optional
    public class GridViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(PersonGridModel personGridModel)
        {
            //ViewData["EmployeesDescription"] = personGridModel;
            return View("Sample",personGridModel); //invoked a partial view Views/Shared/Components/Grid/Default.cshtml
        }
    }
}
