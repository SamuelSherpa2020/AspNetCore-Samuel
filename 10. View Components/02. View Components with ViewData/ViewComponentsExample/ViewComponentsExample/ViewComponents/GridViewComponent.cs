using Microsoft.AspNetCore.Mvc;
using ViewComponentsExample.Models;

namespace ViewComponentsExample.ViewComponents
{
    //[ViewComponent] the attribute is optional
    public class GridViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            PersonGridModel personGridModel = new PersonGridModel()
            {
                GridTitle = "Employee Description",
                Persons = new List<Person>() {
                    new Person() { Name = "Samuel", JobTitle = "Sr. Software & DevOps Engineer" },
                    new Person() { Name = "Kailash", JobTitle = "Sr. React" },
                    new Person() { Name = "Suman", JobTitle = "Sr. Dotnet" },
                    new Person() { Name = "Sahil", JobTitle = "Sr. Database Administrator" },
                    new Person() { Name = "Manjil", JobTitle = "Sr. Quality Assuarance" }
                }
            };
            ViewData["EmployeesDescription"] = personGridModel;
            return View("Sample"); //invoked a partial view Views/Shared/Components/Grid/Default.cshtml
        }
    }
}
