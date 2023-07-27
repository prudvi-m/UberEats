using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using UberEats.Models;

public class MenuItemController : Controller
{
    private readonly UberContext _context;

    public MenuItemController(UberContext context)
    {
        _context = context;
    }

    public IActionResult Add(int partnerId)
    {
        ViewBag.MenuCategories = _context.MenuCategories.ToList();
        return View(new MenuItem { PartnerID = partnerId});
    }

    [HttpPost]
    public async Task<IActionResult> Add(MenuItem menuItem)
    {
        if (ModelState.IsValid)
        {
            _context.MenuItems.Add(menuItem);
            await _context.SaveChangesAsync();
            return RedirectToAction("List", new { partnerId = menuItem.PartnerID });
        }

        // If model state is not valid, fetch the list of available MenuCategories for the dropdown select list
        ViewBag.MenuCategories = _context.MenuCategories.ToList();
        return View(menuItem);
    }

    // public IActionResult List(int partnerId)
    // {
    //     // Retrieve the partner along with their associated MenuItems and MenuCategory
    //     var items = _context.MenuItems 
    //             .Where(p => p.PartnerID == partnerId)
    //             .OrderBy(p => p.MenuItemID).ToList();

    //     if (items == null)
    //     {
    //         return NotFound();
    //     }

    //     // use ViewBag to pass category data to view
    //     ViewBag.MenuCategories = _context.MenuCategories.ToList();
    //     ViewBag.SelectedMenuCategoryName = "All";

    //     return View(items);
    // }

    public IActionResult List(int partnerId,string id = "All")
    {
        List<MenuItem> items;
        if (id == "All")
        {
            items = _context.MenuItems
                .Include(mi => mi.MenuCategory)
                .Where(p => p.PartnerID == partnerId)
                .OrderBy(p => p.MenuItemID).ToList();
        }
        else
        {
            items = _context.MenuItems
                .Include(mi => mi.MenuCategory) 
                .Where(p => p.MenuCategory.Name == id && p.PartnerID == partnerId)
                .OrderBy(p => p.MenuItemID).ToList();
        }
        var partner = _context.Partners.FirstOrDefault(p => p.PartnerID == partnerId);
        string BussinessName = partner?.BusinessName ?? string.Empty;

        ViewBag.partnerId = partnerId;
        ViewBag.BussinessName = BussinessName;
        ViewBag.MenuCategories = _context.MenuCategories.ToList();
        ViewBag.SelectedMenuCategoryName = id;

        // bind items to view
        return View(items);
    }

    public IActionResult Delete(int id)
    {
        var menuItem = _context.MenuItems.FirstOrDefault(mi => mi.MenuItemID == id);
        return View(menuItem);
    }

    [HttpPost]
    public IActionResult Delete(MenuItem menuItem)
    {
        menuItem = _context.MenuItems.FirstOrDefault(mi => mi.MenuItemID == menuItem.MenuItemID);
        if (menuItem != null)
        {
            _context.MenuItems.Remove(menuItem);
            _context.SaveChanges();
        }
        TempData["message"] = "Successfully deleted the item.";
        return RedirectToAction("List", new { partnerId = menuItem.PartnerID });
    }

    public IActionResult Update(int id)
    {
        // Fetch the MenuItem by id and include the associated MenuCategory
        var menuItem = _context.MenuItems.Include(mi => mi.MenuCategory).FirstOrDefault(mi => mi.MenuItemID == id);
        if (menuItem == null)
        {
            return NotFound();
        }

        // Fetch the list of available MenuCategories for the dropdown select list
        ViewBag.MenuCategories = _context.MenuCategories.ToList();
        return View(menuItem);
    }

    [HttpPost]
    public async Task<IActionResult> Update(MenuItem menuItem)
    {
        if (ModelState.IsValid)
        {
            _context.MenuItems.Update(menuItem);
            await _context.SaveChangesAsync();
            return RedirectToAction("List", new { partnerId = menuItem.PartnerID });
        }

        ViewBag.MenuCategories = _context.MenuCategories.ToList();
        return View(menuItem);
    }
}
