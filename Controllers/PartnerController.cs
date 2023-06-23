using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using UberEats.Models;

namespace UberEats.Controllers
{
    public class PartnerController : Controller
    {
        private UberContext context;
        private List<Driver> categories;
       
        public PartnerController(UberContext ctx)
        {
            context = ctx;
            categories = context.Drivers
                    .OrderBy(c => c.DriverID)
                    .ToList();
            ViewBag.Drivers = categories;
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
            ViewBag.Drivers = categories;
            return View("add",partner);
        }
       
        [HttpPost]
        public IActionResult add(Partner partner)
        {
            context.Partners.Add(partner);
            context.SaveChanges();
            TempData["Message"] = "Partner Application "+partner.BusinessName+"  has been received.We will email you once the application has been recieved";
            return RedirectToAction("","Home");  
        }
    }
}
