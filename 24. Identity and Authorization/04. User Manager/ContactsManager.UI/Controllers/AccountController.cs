using ContactsManager.Core.Domain.IdentityEntities;
using ContactsManager.Core.DTO;
using CRUDExample.Controllers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ContactsManager.UI.Controllers
{

    [Route("[controller]/[action]")]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public AccountController(UserManager<ApplicationUser> _applicationUser)
        {
            _userManager = _applicationUser;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {
            //to do: Store user register detail in identity database
            if (!ModelState.IsValid)
            {
                ViewBag.Error = ModelState.Values.SelectMany(temp => temp.Errors)
                    .Select(temp => temp.ErrorMessage)
                    .ToList();
                return View(registerDTO);

            }
            else
            {
                ApplicationUser user = new ApplicationUser() { 
                UserName = registerDTO.Email,
                PersonName = registerDTO.PersonName,
                Email = registerDTO.Email,
                PhoneNumber = registerDTO.Phone,
                };

                IdentityResult identityResult = await _userManager.CreateAsync(user);

                if (identityResult.Succeeded)
                {
                    return RedirectToAction(nameof(PersonsController.Index), "Persons");
                }
                else
                {
                    foreach (IdentityError erorr in identityResult.Errors)
                    {
                        ModelState.AddModelError("Register", erorr.Description);
                    }
                }
            }
            return RedirectToAction(nameof(PersonsController.Index),"Persons");
        }
    }
}
