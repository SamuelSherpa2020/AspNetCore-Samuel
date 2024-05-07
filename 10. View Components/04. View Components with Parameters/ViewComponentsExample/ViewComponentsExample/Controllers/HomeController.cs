﻿using Microsoft.AspNetCore.Mvc;

namespace ViewComponentsExample.Controllers
{
    public class HomeController : Controller
    {

        [Route("/")]
        [Route("/home")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("/about")]
        public IActionResult About()
        {
            return View();
        }
    }
}
