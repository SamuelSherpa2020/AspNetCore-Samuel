using Microsoft.AspNetCore.Mvc;
using ViewExample.Models;

namespace ViewExample.Controllers
{
    public class HomeController : Controller
    {

        [Route("home")]
        public IActionResult Index()
        {
            ViewData["title"] = "AspNet Core C# blocks and Expressions";

            List<Person> people = new List<Person>{
                new Person{ Name = "Samuel",DOB = DateTime.Parse("2000-07-02"),PersonGender = Gender.Male},
                new Person{ Name = "Rachel",DOB = Convert.ToDateTime("2001-08-02"),PersonGender = Gender.Female},
                new Person{ Name = "Suman",DOB = Convert.ToDateTime("2007-10-02"),PersonGender = Gender.Others}
                                                  };
            ViewData["people"]= people;
            ViewBag.People = people;
            return View(); //Views/Home/Index.cshtml
        }
    }
}
