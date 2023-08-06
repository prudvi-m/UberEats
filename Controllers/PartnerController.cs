using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using UberEats.Models;
using UberEats.Models.DataLayer;
using UberEats.Models.DataLayer.Reporsitories;
using UberEats.Models.Grid;
using UberEats.Models.ViewModel;

namespace UberEats.Controllers
{
    public class PartnerController : Controller
    {
        private UberContext context;
        private List<Category> categories;
        private Repository<Partner> data { get; set; }

        public PartnerController(UberContext ctx)
        {
            data = new Repository<Partner>(ctx);
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

            ViewBag.Categories = categories;
            ViewBag.SelectedCategoryName = id;

            return View(products);
        }
        public IActionResult SortedList(PartnerGriddata values, string id = "All")
        {
            var options = new QueryOptions<Partner>
            {
                Includes = "Category",
                OrderByDirection = values.SortDirection,
                PageNumber = values.PageNumber,
                PageSize = values.PageSize,
                OrderBy = d => d.BusinessName,
            };
            if (id != "All")
            {
                options.Where = x
                    => x.Category.Name == id;
            }
            var partnerList = new ViewPartnerModel
            {
                Partners = data.List(options),
                CurrentRoute = values,
                TotalPages = values.GetTotalPages(data.Count)
            };

            ViewBag.SelectedCategoryName = id;
            ViewBag.Categories = categories;

            return View("List", partnerList);
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
            return View("Add", partner);
        }
    }
}
