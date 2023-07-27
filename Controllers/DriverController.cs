using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using UberEats.Models;

namespace UberEats.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DriverController : Controller
    {
        private UberContext context;
        private List<Category> categories;
       
        public DriverController(UberContext ctx)
        {
            context = ctx;
            categories = context.Categories
                    .OrderBy(c => c.CategoryID)
                    .ToList();
            ViewBag.Categories = categories;
        }

        public IActionResult List(string id = "All")
        {
            List<Driver> drivers;
            if (id == "All")
            {
                drivers = context.Drivers
                    .OrderBy(p => p.DriverID).ToList();
            }
            else
            {
                drivers = context.Drivers
                    .OrderBy(p => p.DriverID).ToList();
            }

            // use ViewBag to pass category data to view
            ViewBag.Categories = categories;
            ViewBag.SelectedCategoryName = id;

            // bind drivers to view
            return View(drivers);
        }

      
        public IActionResult Index()
        {
            return View();
        }

       [HttpGet]
        public IActionResult add()
        {
            Driver driver = new Driver(); 
            // ViewBag.Categories = categories;
            return View("add",driver);
        }
       
        [Route("[controller]/add")]
        [HttpPost]
        public IActionResult add(Driver driver)
        {
            context.Drivers.Add(driver);
            context.SaveChanges();
            return RedirectToAction("","Home");  
        }

        public IActionResult VerifyEmail(string email)
        {
            // Check if the email already exists in the database
            // bool isEmailExists = /* Logic to check if email exists */;
            // Access your data access layer or repository to perform the query
            
            bool isEmailExists = context.Drivers.Any(driver => driver.Email == email);

            if (isEmailExists)
            {
                return Json(data: $"Email '{email}' is already in use.");
            }

            return Json(data: true);
        }
    }
}
