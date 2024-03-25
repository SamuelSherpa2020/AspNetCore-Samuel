using Microsoft.AspNetCore.Mvc;

namespace IActionResultExample.Controllers
{
    public class HomeController : Controller
    {

        [Route("book")]
        public IActionResult Index()
        {
            bool bookKey = Convert.ToBoolean(Request.Query.ContainsKey("bookid"));
            var bookId = Convert.ToInt32(Request.Query["bookid"]);
            bool sLoggedIn = Convert.ToBoolean(Request.Query["isLoggedIn"]);

            if (!bookKey)
            {
                Response.StatusCode = 400;
                return Content("The bookid is not supplied");
            }
            if (string.IsNullOrEmpty(Convert.ToString(Request.Query["bookid"])))
            {
                Response.StatusCode = 400;
                return Content("The bookid cannot be null or empty.");
            }
            if (bookId <= 0)
            {
                Response.StatusCode = 400;
                return Content("The bookid cannot be less then or equal to zero.");
            }
            if (bookId > 1000)
            {
                Response.StatusCode = 400;
                return Content("The bookid cannot be greater then 1000.");
            }
            if (!sLoggedIn)
            {
                Response.StatusCode = 401;
                return Content("The authentication is required.");
            }
            return File("/simplefile1.pdf","application/pdf");
        }
    }
}
