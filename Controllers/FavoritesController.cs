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
            // get full partner data from database
            partner = context.Partners
                 .Where(t => t.PartnerID == partner.PartnerID)
                 .FirstOrDefault() ?? new Partner();

            // add partner to favorite partners in session and cookie
            var session = new UberSession(HttpContext.Session);
            var cookies = new UberCookies(Response.Cookies);

            var partners = session.GetMyPartners();
            partners.Add(partner);
            session.SetMyPartners(partners);        
            cookies.SetMyPartnerIds(partners);

            // set add message
            TempData["message"] = $"{partner.BusinessName} added to your favorites";

            // redirect to Home page
            return RedirectToAction("Index", "Home", 
                new {
                    ActiveConf = session.GetActiveConf(),
                    ActiveDiv = session.GetActiveDiv()
                });
        }

        [HttpPost]
        public RedirectToActionResult Delete()
        {
            // delete favorite partners from session and cookie
            var session = new UberSession(HttpContext.Session);
            var cookies = new UberCookies(Response.Cookies);

            session.RemoveMyPartners();
            cookies.RemoveMyPartnerIds();

            // set delete message
            TempData["message"] = "Favorite partners cleared";

            // redirect to Home page
            return RedirectToAction("Index", "Home",
                new {
                    ActiveConf = session.GetActiveConf(),
                    ActiveDiv = session.GetActiveDiv()
                });
        }
    }
}