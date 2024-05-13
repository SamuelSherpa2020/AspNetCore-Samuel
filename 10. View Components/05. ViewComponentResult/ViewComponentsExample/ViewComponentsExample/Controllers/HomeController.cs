using Microsoft.AspNetCore.Mvc;
using ViewComponentsExample.Models;

namespace ViewComponentsExample.Controllers
{
    public class HomeController : Controller
    {

        [Route("/")]
        [Route("~/home")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("about")]
        public IActionResult About()
        {
            return View();
        }

        [Route("friends-list")]

        public IActionResult LoadFriendsList()
        {
            PersonGridModel personGridModel = new PersonGridModel()
            {
                GridTitle = "Samuel - Hobbies",
                Persons = new List<Person>()
        {
            new Person(){Name="Futsal", JobTitle="I love to play futsal, since it's very competetive and intense"},
            new Person(){Name="Youtube - informative", JobTitle="I spend almost 3.5 hours on avg on mobile screen but all of it is youtube"},
            new Person(){Name="Singing", JobTitle="I do love playing guitar and singing, mostly christian songs"},
            new Person(){Name="Coding", JobTitle="I love coding and learning"}
        }
            };
            return ViewComponent("Grid",personGridModel);
        }
    }
}
