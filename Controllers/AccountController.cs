using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using UberEats.Models;

namespace UberEats.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<User> userManager;
        private UberContext context;
        private SignInManager<User> signInManager;

        public AccountController(UserManager<User> userMngr,
            SignInManager<User> signInMngr,UberContext ctx)
        {
            context = ctx;
            userManager = userMngr;
            signInManager = signInMngr;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new UberEats.Models.User { 
                    UserName = model.Username,
                    Firstname = model.Firstname,
                    Lastname = model.Lastname,
                    Email = model.Email
                };
                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent : false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors) 
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult LogIn(string returnURL = "")
        {
            var model = new LoginViewModel { ReturnUrl = returnURL };
            return View(model);
        }

        // [HttpPost]
        // public async Task<IActionResult> LogIn(LoginViewModel model)
        // {
        //     if (ModelState.IsValid)
        //     {                
        //         var result = await signInManager.PasswordSignInAsync(
        //             model.Username, model.Password, isPersistent: model.RememberMe, 
        //             lockoutOnFailure: false);

        //         if (result.Succeeded)
        //         {
        //             if (!string.IsNullOrEmpty(model.ReturnUrl) && 
        //                 Url.IsLocalUrl(model.ReturnUrl))
        //             {
        //                 return Redirect(model.ReturnUrl);
        //             }
        //             else
        //             {
        //                 return RedirectToAction("Index", "Home");
        //             }
        //         }
        //     }
        //     ModelState.AddModelError("", "Invalid username/password.");
        //     return View(model);
        // }


        [HttpPost]
        public async Task<IActionResult> LogIn(LoginViewModel model)
        {
            // Query the database to find the Partner with the matching BusinessEmail
            var partner = context.Partners.FirstOrDefault(p => p.BusinessEmail == model.Username);

            if (partner == null)
            {
                // Partner with the specified email was not found
                return NotFound();
            }

            // Partner with the specified email was found, do something with it
            return RedirectToAction("List", "MenuItem", new { partnerId = partner.PartnerID });
        }

        public ViewResult AccessDenied()
        {
            return View();
        }
    }
}