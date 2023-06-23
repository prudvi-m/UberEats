using Microsoft.AspNetCore.Mvc;

namespace UberEats.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BusinessController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}