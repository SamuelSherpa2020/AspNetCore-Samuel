using Microsoft.AspNetCore.Mvc;
using ModelValidatonExample.Models;

namespace ModelValidatonExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("register")]
        public IActionResult Index(Person person)
        {
            if (!ModelState.IsValid)
            {
                List<string> errorMessages = new List<string>();
                foreach (var item in ModelState.Values)
                {
                    if (item.Errors.Count > 0)
                    {

                    }
                    foreach (var error in item.Errors)
                    {
                        errorMessages.Add(error.ErrorMessage);
                    }
                }
                //Below is linq with which we made the above code short
                //if (ModelState.Values.Errors.Count > 0)
                //{

                //}
                string errorList = string.Join("\n", ModelState.Values
                    .SelectMany(errors => errors.Errors)
                    .Select(errorMessage => errorMessage.ErrorMessage).ToList());

                string fullErrorMessage = string.Join(", ", ModelState.Values
                    .Where(v => v.Errors.Count > 0) // using count of erors
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));


                return BadRequest(errorList);
            }
            return Content($"{person}");
        }
    }
}
