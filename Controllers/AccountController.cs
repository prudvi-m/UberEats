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


        [HttpPost]
        public async Task<IActionResult> LogIn(LoginViewModel model)
        {
            var partner = context.Partners.FirstOrDefault(p => p.BusinessEmail == model.Username);

            if (partner == null)
            {
                return NotFound();
            }

            return RedirectToAction("List", "Item", new { partnerId = partner.PartnerID });
        }

        public ViewResult AccessDenied()
        {
            return View();
        }
    }
}