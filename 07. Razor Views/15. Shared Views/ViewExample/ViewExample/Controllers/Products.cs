using Microsoft.AspNetCore.Mvc;
using ViewExample.Models;

namespace ViewExample.Controllers
{
    public class Products : Controller
    {
        [Route("products/All")]
        public IActionResult All()
        {
            Product product = new Product()
            {
                ProductId = 1,
                ProductName = "TV"
            };
            return View(product);
        }
    }
}
