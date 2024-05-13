using Microsoft.AspNetCore.Mvc;

namespace IActionResultExample.Controllers
{
    public class StoreController : Controller
    {

        [Route("store/books")]
        public IActionResult Books()
        {
            return Content("<h1>This is a books store</h1>", "text/html");
        }
    }
}
