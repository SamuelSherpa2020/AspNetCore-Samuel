using Microsoft.AspNetCore.Mvc;
using ModelValidatonExample.Models;

namespace ModelValidatonExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("register")]
        public IActionResult Index(Person person)
        {
            return Content($"{person}");
        }
    }
}
