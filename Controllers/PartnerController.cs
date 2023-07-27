using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using UberEats.Models;

namespace UberEats.Controllers
{
    public class PartnerController : Controller
    {
        private UberContext context;
        private List<Category> categories;
       
        public PartnerController(UberContext ctx)
        {
            context = ctx;
            categories = context.Categories
                    .OrderBy(c => c.CategoryID)
                    .ToList();
            ViewBag.Categories = categories;
        }

        public IActionResult List(string id = "All")
        {
            List<Partner> products;
            if (id == "All")
            {
                products = context.Partners
                    .OrderBy(p => p.PartnerID).ToList();
            }
            else
            {
                products = context.Partners
                    .Where(p => p.Category.Name == id)
                    .OrderBy(p => p.PartnerID).ToList();
            }

            // use ViewBag to pass category data to view
            ViewBag.Categories = categories;
            ViewBag.SelectedCategoryName = id;

            // bind products to view
            return View(products);
        }
      
        public IActionResult Index()
        {
            return View();
        }

       [Route("[controller]/add")]
       [HttpGet]
        public IActionResult add()
        {
            Partner partner = new Partner(); 
            ViewBag.Categories = categories;
            return View("add",partner);
        }
       
        [HttpPost]
        public IActionResult Add(Partner partner)
        {
            if (ModelState.IsValid)
            {
                context.Partners.Add(partner);
                context.SaveChanges();
                TempData["Message"] = "Partner Application " + partner.BusinessName + " has been received. We will email you once the application has been received.";
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Categories = categories;
            // If ModelState is not valid, return to the add view with validation errors
            return View("Add", partner);
        }
    }
}
