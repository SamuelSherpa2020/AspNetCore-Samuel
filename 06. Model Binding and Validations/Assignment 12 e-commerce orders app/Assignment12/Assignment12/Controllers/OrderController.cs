using Assignment12.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment12.Controllers
{
    public class OrderController : Controller
    {
        [HttpPost]
        [Route("/order")]
        public IActionResult Index(Order order)
        {
            if (!ModelState.IsValid)
            {
                string errorName = string.Join("\n", ModelState.Values.SelectMany(errors => errors.Errors)
                                        .Select(errorMessage => errorMessage.ErrorMessage));
                return BadRequest(errorName);
            }
            else
            {
                Random random = new Random();
                int randomOrderNumber = random.Next(1, 99999);
                Response.StatusCode = 200;  
                return Json(new { orderNumber = randomOrderNumber});
            }
        }
    }
}
