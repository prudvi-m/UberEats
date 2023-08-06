using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Web.Mvc;
using UberEats.Areas.Admin.Models;
using UberEats.Models;
using UberEats.Models.ViewModel;

namespace UberEatsApplication.Areas.Admin.Controllers
{
    [Authorize(Roles ="Admin")]
    [Area("Admin")]

    public class UserController : Microsoft.AspNetCore.Mvc.Controller
    {
        private UserManager<User> userManager;
        private RoleManager<IdentityRole> roleManager;

        public UserController(UserManager<User> userMngr,
            RoleManager<IdentityRole> roleMngr)
        {
            userManager = userMngr;
            roleManager = roleMngr;
        }
        public async Task<IActionResult> Index()
        {
            List<User> users = new List<User>();
            foreach (User user in userManager.Users)
            {
                user.RoleNames = await userManager.GetRolesAsync(user);
                users.Add(user);
            }
            UserViewModel model = new UserViewModel
            {
                Users = users,
                Roles = roleManager.Roles
            };
            return View(model);
        }

        [Microsoft.AspNetCore.Mvc.HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            User user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await userManager.DeleteAsync(user);
                if (!result.Succeeded) // if failed
                {
                    string errorMessage = "";
                    foreach (IdentityError error in result.Errors)
                    {
                        errorMessage += error.Description + " | ";
                    }
                    TempData["message"] = errorMessage;
                }
            }
            return RedirectToAction("Index");
        }

        [Microsoft.AspNetCore.Mvc.HttpGet]
        public IActionResult Add()
        {

            ViewBag.Roles = roleManager.Roles;
            return View();
        }

        [Microsoft.AspNetCore.Mvc.HttpPost]
        public async Task<IActionResult> Add(UberEats.Models.ViewModel.RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User { UserName = model.Username };
                var result = await userManager.CreateAsync(user, model.Password);
                IdentityRole adminRole = await roleManager.FindByIdAsync(model.RoleID);
                await userManager.AddToRoleAsync(user, adminRole.Name);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
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

        public IActionResult AddRole(string id)
        {
            ViewBag.Roles = roleManager.Roles;
            ViewBag.UserID = id;
            return View();
        }

        [Microsoft.AspNetCore.Mvc.HttpPost]
        public async Task<IActionResult> AddNewRole(string UserID, string RoleId)
        {
            IdentityRole adminRole = await roleManager.FindByIdAsync(RoleId);
                User user = await userManager.FindByIdAsync(UserID);
                await userManager.AddToRoleAsync(user, adminRole.Name);
            return RedirectToAction("Index");
        }

        [Microsoft.AspNetCore.Mvc.HttpPost]
        public async Task<IActionResult> RemoveRole(string id, string roleid)
        {
            User user = await userManager.FindByIdAsync(id);
            var result = await userManager.RemoveFromRoleAsync(user, roleid);
            if (result.Succeeded) { }
            return RedirectToAction("Index");
        }

        [Microsoft.AspNetCore.Mvc.HttpPost]
        public async Task<IActionResult> DeleteRole(string id)
        {
            IdentityRole role = await roleManager.FindByIdAsync(id);
            var result = await roleManager.DeleteAsync(role);
            if (result.Succeeded) { }
            return RedirectToAction("Index");
        }

        [Microsoft.AspNetCore.Mvc.HttpPost]
        public async Task<IActionResult> CreateAdminRole()
        {
            var result = await roleManager.CreateAsync(new IdentityRole("Admin"));
            if (result.Succeeded) { }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> SaveRole(string RoleName)
        {
            var result = await roleManager.CreateAsync(new IdentityRole(RoleName));
            if (result.Succeeded) { }
            return RedirectToAction("Index");
        }
    }

}
