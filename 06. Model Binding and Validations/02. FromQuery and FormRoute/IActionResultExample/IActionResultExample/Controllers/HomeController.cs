using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace IActionResultExample.Controllers
{
    public class HomeController : Controller
    {

        [Route("bookstore/{bookId?}/{isLoggedIn?}")]
        public IActionResult Index([FromRoute]int?bookId,[FromQuery]bool?isLoggedIn)
        {

            #region Error Handling in isLoggedIn 

            try
            {
                isLoggedIn = Convert.ToBoolean(Request.Query["isLoggedIn"]);
            }
            catch (FormatException ex)
            {
                Response.StatusCode = 400;
                //return Content("The value provided for 'isLoggedIn' is not a valid boolean.");
                return Content($"{ex.Message}");
                //throw new FormatException($"{ex.Message}");
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest("isLoggedin cannot be null");
            }
            catch (UnauthorizedAccessException ex)
            {
                //return Content($"{ex.Message}");
                //return Unauthorized("Invalid Authentication is made.");
                return Unauthorized($"{ex.Message}");
            }
            #endregion

            if (bookId.HasValue.Equals(false))
            {
                return BadRequest("The bookid is not supplied");
            }
            if (string.IsNullOrEmpty(Convert.ToString(Request.Query["bookid"])))
            {
                return BadRequest("The bookid cannot be null or empty.");
            }
            if (bookId <= 0)
            {
                return BadRequest();
            }
            if (bookId > 1000)
            {
                return NotFound("There's no available book on that id.");
            }
            if (isLoggedIn.HasValue.Equals(false))
            {
                return Unauthorized("Use must be logged in");
            }
            //return File("/simplefile1.pdf", "application/pdf");

            //return new RedirectToActionResult("Books", "Store", new { },permanent:true); // permanently telling browser to remember that the url has been changed permanently.

            //return RedirectToActionPermanent("Books","Store", new { Id=bookId});

            return Redirect($"store/books/{bookId}");
        }
    }
}
