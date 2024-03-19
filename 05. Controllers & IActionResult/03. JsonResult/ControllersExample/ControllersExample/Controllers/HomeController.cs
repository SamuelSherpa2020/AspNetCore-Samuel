using Microsoft.AspNetCore.Mvc;

namespace ControllersExample.Controllers
{
    
    public class HomeController : Controller
    {
        //public HomeController() { }
        [Route("Home/Index")]
        [Route("/")]
        public ContentResult Index()
        {
            return Content("<h1>Hello there</h1></br><h2>I am calling you from Index</h2>","text/html");
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
        [Route("TryContentResult")]
        public ContentResult TryContentResult()
        {
            ContentResult obj = new ContentResult()
            {
                Content = "wow",
                ContentType = "text/html"
            };
            //obj.Content = "hello";
            //obj.ContentType= "text/html";

            return obj;
            //return new ContentResult()
            //{
            //    Content = "<h1>Hello there, I am from TryContentResult</h1>",
            //    ContentType = "text/html"
            //};
            
        }
    }
}
