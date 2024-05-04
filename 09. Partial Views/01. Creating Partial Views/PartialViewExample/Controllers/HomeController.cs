using Microsoft.AspNetCore.Mvc;

namespace PartialViewExample
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("/about/")]
        public IActionResult About()
        {
            return View();
        }
    }

}