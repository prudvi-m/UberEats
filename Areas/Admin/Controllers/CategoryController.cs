using System.Linq;
using Microsoft.AspNetCore.Mvc;
using UberEats.Models;

namespace UberEats.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private UberContext context;

        public CategoryController(UberContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index()
        {
            return RedirectToAction("List");
        }

        [Route("[area]/Drivers/{id?}")]
        public IActionResult List()
        {
            var categories = context.Drivers
                .OrderBy(c => c.DriverID).ToList();
            return View(categories);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            return View("AddUpdate", new Driver());
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            ViewBag.Action = "Update";
            var category = context.Drivers.Find(id);
            return View("AddUpdate", category);
        }

        [HttpPost]
        public IActionResult Update(Driver category)
        {
            if (ModelState.IsValid)
            {
                if (category.DriverID == 0)
                {
                    context.Drivers.Add(category);
                }
                else
                {
                    context.Drivers.Update(category);
                }
                context.SaveChanges();
                return RedirectToAction("List");
            }
            else
            {
                ViewBag.Action = "Save";
                return View("AddUpdate");
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Driver category = context.Drivers.Find(id) ?? new Driver();
            return View(category);
        }


        [HttpPost]
        public IActionResult Delete(Driver category)
        {
            context.Drivers.Remove(category);
            context.SaveChanges();
            return RedirectToAction("List");
        }
    }
}