using Microsoft.AspNetCore.Mvc;

namespace IActionResultExample.Controllers
{
    public class StoreController : Controller
    {

        [Route("store/books/{id}")]
        public IActionResult Books()
        {
            var id = Convert.ToInt32(Request.RouteValues["id"]);
            return Content($"<h1>The id of the book is: {id}</h1>", "text/html");
        }
    }
}
