using Microsoft.AspNetCore.Mvc;

namespace ControllersExample.Controllers
{
    
    public class HomeController : Controller
    {
        //public HomeController() { }
        [Route("Home/Index")]
        [Route("/")]
        public string Index()
        {
            return ("Hello from Index");
        }

        [Route("Home/try")]
        public string  Try()
        {
            return ("Hello from try");
        }

        [Route("Home/AboutUs")]
        public string AboutUs()
        {
            string apple = HttpContext.Request.Path;
            return apple;

        }

        [Route("Home/ContactUs/{mobile:regex(^\\d{{10}}$)}")]
        public string Contact()
        {
            //var phoneNumber = HttpContext.Request.RouteValues["mobile"];

             return("The given phone number is haha");
        }
    }
}
