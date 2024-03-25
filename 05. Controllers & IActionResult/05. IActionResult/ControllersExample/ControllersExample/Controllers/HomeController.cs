using Microsoft.AspNetCore.Mvc;
using ControllersExample.Models;

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

        [Route("Person")]
        public JsonResult Person()
        {
            Person child = new Person()
            {
                Id = Guid.NewGuid(),
                Name = "Samuel",
                age = 23,
                Address = "Damak"
            };
            return Json(child);
        }

        [Route("file-download1")]
        public VirtualFileResult FileDownload1()
        {
            //return new VirtualFileResult("/simplefile1.pdf","application/pdf");
            return  File("/simplefile1.pdf", "application/pdf");

        }

        [Route("file-download2")]
        public PhysicalFileResult FileDownload2()
        {
            //return new PhysicalFileResult(@"C:\Users\asus\Downloads\simplefile2.pdf", "application/pdf");
            return  PhysicalFile(@"C:\Users\asus\Downloads\simplefile2.pdf", "application/pdf");
        }

        [Route("file-download3")]
        public FileContentResult FileDownload3()
        {
            byte[] byteFile = System.IO.File.ReadAllBytes("C:\\Users\\asus\\Downloads\\simplefile3.pdf");
            return  File(byteFile, "application/pdf");
        }


        public IActionResult Calculator()
        {
            byte[] byteFile = System.IO.File.ReadAllBytes("C:\\Users\\asus\\Downloads\\simplefile3.pdf");
            return  File(byteFile, "application/pdf");
        }
    }
}
