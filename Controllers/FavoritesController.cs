using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UberEats.Models;

namespace UberEats.Controllers
{
    public class FavoritesController : Controller
    {
        private UberContext context;
        public FavoritesController(UberContext ctx) => context = ctx;

        [HttpGet]
        public ViewResult Index()
        {
            var session = new UberSession(HttpContext.Session);
            var model = new PartnersViewModel
            {
                ActiveConf = session.GetActiveConf(),
                ActiveDiv = session.GetActiveDiv(),
                Partners = session.GetMyPartners()
            };

            return View(model);
        }

        [HttpPost]
        public RedirectToActionResult Add(Partner partner)
        {
            partner = context.Partners
                 .Where(t => t.PartnerID == partner.PartnerID)
                 .FirstOrDefault() ?? new Partner();

            var session = new UberSession(HttpContext.Session);
            var cookies = new UberCookies(Response.Cookies);

            var partners = session.GetMyPartners();
            partners.Add(partner);
            session.SetMyPartners(partners);        
            cookies.SetMyPartnerIds(partners);

            TempData["message"] = $"{partner.BusinessName} added to your favorites";

            return RedirectToAction("Index", "Home", 
                new {
                    ActiveConf = session.GetActiveConf(),
                    ActiveDiv = session.GetActiveDiv()
                });
        }

        [HttpPost]
        public RedirectToActionResult Delete()
        {
            var session = new UberSession(HttpContext.Session);
            var cookies = new UberCookies(Response.Cookies);

            session.RemoveMyPartners();
            cookies.RemoveMyPartnerIds();

            TempData["message"] = "Favorite partners cleared";

            return RedirectToAction("Index", "Home",
                new {
                    ActiveConf = session.GetActiveConf(),
                    ActiveDiv = session.GetActiveDiv()
                });
        }
    }
}