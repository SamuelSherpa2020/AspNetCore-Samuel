using Assignment10.Models;
using Microsoft.AspNetCore.Mvc;

namespace Assignment10.Controllers
{
    public class BankController : Controller
    {

        [Route("/")]
        [HttpGet]
        public ContentResult Index()
        {
            Response.StatusCode = 200;
            return Content("Welcome to the Best Bank", "text/plain");
        }

        [Route("account-details")]
        public JsonResult AccountDetails()
        {
            Response.StatusCode = 200;
            BankAccountDetail property = new BankAccountDetail()
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

        [Route("get-current-balance/{accountNumber:int?}")]
        public IActionResult GetCurrentBalance()
        {
            
            object? accountNumberObj;
            if ((HttpContext.Request.RouteValues.TryGetValue("accountNumber", out accountNumberObj)) && (accountNumberObj is string accountNumber))
            {
                if (string.IsNullOrEmpty(accountNumber))
                {
                    return BadRequest("Account number cannot be empty");
                }
                if (int.TryParse(accountNumber, out int accountNumberInt32))
                {
                    BankAccountDetail newbankAccountDetail = new()
                    {
                        accountNumber = 1001,
                        accountHolderName = "Example Name",
                        currentBalance = 5000
                    };
                    if (accountNumberInt32.Equals(1001))
                    {
                        return Content(newbankAccountDetail.currentBalance.ToString());
                    }
                    else
                    {
                        return BadRequest("account number must be 1001");
                    }
                }
                else
                {
                    return BadRequest("Account number is not in the correct format");
                }
            }
            else
            {
                return BadRequest("Account Number is not supplied.");
            }
        }



        //[Route("get-current-balance")]
        //public IActionResult GetCurrentBalanceAccount()
        //{
        //    return Content("Account Number sould be supplied", "text/plain");
        //}

    }
}
