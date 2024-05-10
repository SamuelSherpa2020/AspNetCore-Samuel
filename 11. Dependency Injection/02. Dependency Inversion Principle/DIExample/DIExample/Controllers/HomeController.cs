using Microsoft.AspNetCore.Mvc;
using Services;

namespace DIExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly CitiesServices _cities;
        public HomeController()
        {
            _cities = new CitiesServices();
        }

        [Route("/")]
        public IActionResult Index()
        {
            List<string> cities = _cities.GetCities();
            return View(cities);
        }
    }
}
