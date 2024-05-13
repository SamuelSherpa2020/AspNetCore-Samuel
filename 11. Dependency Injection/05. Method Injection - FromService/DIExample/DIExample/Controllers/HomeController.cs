using Microsoft.AspNetCore.Mvc;
using ServiceContractor;
using Services;

namespace DIExample.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ICitiesServices _icitiesServices;
        //public HomeController(ICitiesServices icitiesServices)
        //{
        //    _icitiesServices = icitiesServices;
        //}

        [Route("/")]
        public IActionResult Index([FromServices]ICitiesServices _icititesServices) // use of [FromServices] helps to bring the instance of the interface service from IoC Container
        {
            List<string> cities = _icititesServices.GetCities();
            return View(cities);
        }
    }
}
