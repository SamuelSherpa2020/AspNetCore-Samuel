using Microsoft.AspNetCore.Mvc;

namespace ViewExample.Controllers
{
    public class HomeController : Controller
    {

        [Route("home")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
