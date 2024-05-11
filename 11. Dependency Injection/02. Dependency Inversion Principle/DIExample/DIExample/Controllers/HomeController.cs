using Microsoft.AspNetCore.Mvc;
using ServiceContractor;
using Services;

namespace DIExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICitiesServices _icitiesServices;
        public HomeController(ICitiesServices icitiesServices)
        {
            _icitiesServices = icitiesServices;
        }

        [Route("/")]
        public IActionResult Index()
        {
            List<string> cities = _icitiesServices.GetCities();
            return View(cities);
        }
    }
}
