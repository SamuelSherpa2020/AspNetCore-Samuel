using Microsoft.AspNetCore.Mvc;

namespace IActionResultExample.Controllers
{
    public class Ramailo:ControllerBase
    {
        [Route("sports/football")]
        public IActionResult Football()
        {
            return Content("I love to play football","text/plain");
        }
    }
}
