using IActionResultExample.Model;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace IActionResultExample.Controllers
{
    public class HomeController : Controller
    {

        [Route("bookstore/{bookId?}/{isLoggedIn?}")]
        public IActionResult Index(int?bookId,bool?isLoggedIn,Book book)
        {


            #region Validation Of Request Data
            if (bookId.HasValue.Equals(false))
            {
                return BadRequest("The bookid is not supplied");
            }
            if (bookId <= 0)
            {
                return BadRequest();
            }
            if (bookId > 1000)
            {
                return NotFound("There's no available book on that id.");
            }
            if (isLoggedIn.Equals(false))
            {
                return Unauthorized("User must be logged in");
            }
            #endregion
            //return File("/simplefile1.pdf", "application/pdf");

            //return new RedirectToActionResult("Books", "Store", new { },permanent:true); // permanently telling browser to remember that the url has been changed permanently.

            //return RedirectToActionPermanent("Books","Store", new { Id=bookId});

            //return Redirect($"store/books/{bookId}");
            return Content($"BooId:{bookId} Book: {book}","text/plain");
        }
    }
}
