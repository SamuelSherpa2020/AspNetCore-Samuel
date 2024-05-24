using Microsoft.AspNetCore.Mvc;
using ServiceContractor;
using Services;

namespace DIExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICitiesServices _icitiesServices1;
        private readonly ICitiesServices _icitiesServices2;
        private readonly ICitiesServices _icitiesServices3;

        public HomeController(ICitiesServices icitiesServices1, ICitiesServices icitiesServices2, ICitiesServices icitiesServices3)
        {
            _icitiesServices1 = icitiesServices1;
            _icitiesServices2 = icitiesServices2;
            _icitiesServices3 = icitiesServices3;
        }

        [Route("/")]
        public IActionResult Index()
        {
            List<string> cities = _icitiesServices1.GetCities();

            ViewBag._icitiesServices1 = _icitiesServices1.ICitiesServiceId;
            ViewBag._icitiesServices2 = _icitiesServices2.ICitiesServiceId;
            ViewBag._icitiesServices3 = _icitiesServices3.ICitiesServiceId;

            return View(cities);
        }
    }
}
