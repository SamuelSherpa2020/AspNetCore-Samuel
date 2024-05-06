using Microsoft.AspNetCore.Mvc;
using PartialViewsExample.Models;

namespace PartialViewsExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            ViewData["ListTitle"] = "Cities";
            ViewData["ListItems"] = new List<string>() {
        "Paris",
        "New York",
        "New Mumbai",
        "Rome"
      };
            return View();
        }

        [Route("about")]
        public IActionResult About()
        {
            return View();
        }
        [Route("/programming-languages")]
        public IActionResult ProgrammingLanguage()
        {
            ListModel model = new ListModel()
            {
                TitleName = "Programming Languages",
                ListItems = new List<string>() {
                "C#",
                "C++",
                "Objective C",
                "JavaScript",
                "Python"
                }
            };

            return PartialView("_ListPartialView",model);
        }
    }
}
