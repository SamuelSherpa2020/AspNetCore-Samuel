using Assignment10.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment10.Controllers
{
    public class BankController : Controller
    {

        [Route("/")]
        [HttpGet]
        public IActionResult Index()
        {
            Response.StatusCode = 200;
            return Content("Welcome to the Best Bank", "text/plain");
        }

        [Route("account-details")]
        public JsonResult AccountDetails()
        {
            Response.StatusCode = 200;
            Property property = new Property()
            {
                accountNumber = 1001,
                accountHolderName = "Example Name",
                currentBalance = 5000
            };
            return Json(property);
        }

        [Route("account-statement")]
        public IActionResult AccountStatement()
        {
            Response.StatusCode = 200;
            return File("AccountStatementPDF.pdf", "application/pdf");
        }

        [Route("get-current-balance/{accountNumber}")]
        public IActionResult GetCurrentBalance()
        {
            int balance = Convert.ToInt32(HttpContext.Request.RouteValues["accountNumber"]);
            //return Content($"{balance}", "text/plain");//for task 4
            if (balance.Equals(1001))
            {
                return Content($"{balance}", "text/plain");
            }
            else
            {
                return BadRequest("Account number sould be 1001");

            }
        }

        [Route("get-current-balance")]
        public IActionResult GetCurrentBalanceAccount()
        {
            return Content("Account Number sould be supplied","text/plain");
        }

    }
}
