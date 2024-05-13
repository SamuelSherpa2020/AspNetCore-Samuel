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
        private readonly IServiceScopeFactory _scopeFactory;

        public HomeController(ICitiesServices icitiesServices1, ICitiesServices icitiesServices2, ICitiesServices icitiesServices3, IServiceScopeFactory scopeFactory)
        {
            _icitiesServices1 = icitiesServices1;
            _icitiesServices2 = icitiesServices2;
            _icitiesServices3 = icitiesServices3;
            _scopeFactory = scopeFactory;
        }

        [Route("/")]
        public IActionResult Index()
        {
            List<string> cities = _icitiesServices1.GetCities();

            ViewBag._icitiesServices1 = _icitiesServices1.ICitiesServiceId;
            ViewBag._icitiesServices2 = _icitiesServices2.ICitiesServiceId;
            ViewBag._icitiesServices3 = _icitiesServices3.ICitiesServiceId;

            using (IServiceScope scope = _scopeFactory.CreateScope())
            {
                ICitiesServices _iCitiesService = scope.ServiceProvider.GetRequiredService<ICitiesServices>();
                ViewBag.ICitiesServiceChildScope = _iCitiesService.ICitiesServiceId;
            }

            return View(cities);
        }
    }
}
