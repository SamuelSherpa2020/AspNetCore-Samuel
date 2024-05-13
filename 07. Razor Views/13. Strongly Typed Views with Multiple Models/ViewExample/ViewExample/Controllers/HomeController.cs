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
            ViewData["people"] = people;
            ViewBag.People = people;
            return View(people); //Views/Home/Index.cshtml
        }

        [Route("person-details/{name}")]
        public IActionResult PersonDetails([FromQuery]string name)
        {
            string personName = HttpContext.Request.Query["name"];
            if (personName is null)
            {
                return BadRequest("name cannot be null");
            }
            List<Person> people = new List<Person>(){
                new Person { Name = "Samuel", DOB = DateTime.Parse("2000-07-02"), PersonGender = Gender.Male },
                new Person { Name = "Rachel", DOB = Convert.ToDateTime("2001-08-02"), PersonGender = Gender.Female },
                new Person { Name = "Suman", DOB = Convert.ToDateTime("2007-10-02"), PersonGender = Gender.Others }
            };
            Person? personDetail = people.Where(tempName => tempName.Name == personName).FirstOrDefault();
            return View(personDetail);
        }

        [Route("person-with-product")]
        public IActionResult PersonWithProduct()
        {
            Person person = new Person(){Name = "Sarah",DOB = DateTime.Parse("2000-07-02"),PersonGender = Gender.Male};

            Product product = new Product() { ProductId=1,ProductName="Television"};
            PersonAndProductWrapperModel PAPWM = new PersonAndProductWrapperModel()
            {
                PersonData = person,
                ProductData = product, 
            };
            return View(PAPWM);
        }
    }
}
