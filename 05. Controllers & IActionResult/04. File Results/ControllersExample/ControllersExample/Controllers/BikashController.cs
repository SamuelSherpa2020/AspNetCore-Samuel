using Microsoft.AspNetCore.Mvc;

namespace ControllersExample.Controllers
{
    public class BikashController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
