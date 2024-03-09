using Microsoft.AspNetCore.Mvc;

namespace ControllersExample.Controllers
{
    [Controller]
    public class Home:Controller
    {
        [Route("Home/Index")]
        public string Index()
        {
          return ("Hello from Index");
        }

        [Route("Home/try")]
        public void Try()
        {
            HttpContext.Response.WriteAsync("Hello from try");
        }

        [Route("Home/AboutUs")]
        public string AboutUs()
        {
            return "Hello from AboutUs Page";
        }

        [Route("Home/ContactUs/{mobile:regex(^\\d{{10}}$)}")]
        public string Contact()
        {
            return "Hello from ContactUs";
        }
    }
}
