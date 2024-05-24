﻿using ContactsManager.Core.DTO;
using CRUDExample.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace ContactsManager.UI.Controllers
{

    [Route("[controller]/[action]")]
    public class AccountController : Controller
    {

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Register(RegisterDTO registerDTO)
        {
            //to do: Store user register detail in identity database
            return RedirectToAction(nameof(PersonsController.Index),"Persons");
        }
    }
}
