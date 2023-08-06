using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UberEats.Models;

namespace UberEats.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]

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
        }

        public IActionResult Index()
        {
            return RedirectToAction("List");
        }

        [Route("[area]/[controller]s/{id?}")]
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

            ViewBag.Categories = categories;
            ViewBag.SelectedCategoryName = id;

            return View(products);
        }
        [Route("[area]/[controller]/add")]
        [HttpGet]
        public IActionResult Add()
        {
            Partner partner = new Partner();                

            ViewBag.Action = "Add";
            ViewBag.Categories = categories;

            return View("AddUpdate", partner);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            Partner partner = context.Partners
                .Include(p => p.Category)
                .FirstOrDefault(p => p.PartnerID == id) ?? new Partner();

            ViewBag.Action = "Update";
            ViewBag.Categories = categories;

            return View("AddUpdate", partner);
        }

        [HttpPost]
        public IActionResult Update(Partner partner)
        {
            if (ModelState.IsValid)
            {
                if(partner.PartnerID == 0)
                {
                    context.Partners.Add(partner);
                }
                else 
                {
                    context.Partners.Update(partner);
                    TempData["Message"] = "Partner Application "+partner.BusinessName+"  has been Updated";
                }
                context.SaveChanges();
                return RedirectToAction("List");
            }
            else
            {
                ViewBag.Action = "Save";
                ViewBag.Categories = categories;
                return View("AddUpdate", partner);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Partner partner = context.Partners
                .FirstOrDefault(p => p.PartnerID == id) ?? new Partner();
            return View(partner);
        }

        [HttpPost]
        public IActionResult Delete(Partner partner)
        {
            context.Partners.Remove(partner);
            context.SaveChanges();
            TempData["Message"] = "Partner Application has been Removed";
            return RedirectToAction("List");
        }

        

        [HttpGet]
       
        public IActionResult Approve(int id)
        {
            Partner partner = context.Partners
                .FirstOrDefault(p => p.PartnerID == id) ?? new Partner();
                 ViewBag.Dta="Approve";
                 TempData["data"]="Approve";
              
            return View(partner);
        }

        [HttpPost]
        public IActionResult Approve(Partner partner)
        {
            TempData["data"]="Approve";
            TempData["Message"] = "Partner Application  "+partner.BusinessName+"has been approved";
            return RedirectToAction("List");
        }
    }
}