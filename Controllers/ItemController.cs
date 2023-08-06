using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using UberEats.Models;

public class ItemController : Controller
{
    private readonly UberContext _context;

    public ItemController(UberContext context)
    {
        _context = context;
    }

    public IActionResult Add(int partnerId)
    {
        ViewBag.MenuCategories = _context.MenuCategories.ToList();
        return View(new Item { PartnerID = partnerId});
    }

    [HttpPost]
    public async Task<IActionResult> Add(Item item)
    {
        if (ModelState.IsValid)
        {
            _context.Menu.Add(item);
            await _context.SaveChangesAsync();
            return RedirectToAction("List", new { partnerId = item.PartnerID });
        }

        ViewBag.MenuCategories = _context.MenuCategories.ToList();
        return View(item);
    }

    public IActionResult List(int partnerId,string id = "All")
    {
        List<Item> itemsList;
        if (id == "All") itemsList = _context.Menu.Include(mi => mi.ItemCategory).Where(p => p.PartnerID == partnerId).OrderBy(p => p.ItemID).ToList();
        else itemsList = _context.Menu.Include(mi => mi.ItemCategory) .Where(p => p.ItemCategory.Name == id && p.PartnerID == partnerId).OrderBy(p => p.ItemID).ToList();
        var menuTitle = _context.Partners.FirstOrDefault(p => p.PartnerID == partnerId)?.BusinessName ?? string.Empty;

        ViewBag.menuTitle = "Menu for " + menuTitle;
        ViewBag.partnerId = partnerId;
        ViewBag.MenuCategories = _context.MenuCategories.ToList();
        ViewBag.SelectedItemCategoryName = id;

        return View(itemsList);
    }

    public IActionResult Delete(int id)
    {
        var item = _context.Menu.FirstOrDefault(mi => mi.ItemID == id);
        return View(item);
    }

    [HttpPost]
    public IActionResult Delete(Item item)
    {
        item = _context.Menu.FirstOrDefault(mi => mi.ItemID == item.ItemID);
        if (item != null)
        {
            _context.Menu.Remove(item);
            _context.SaveChanges();
        }
        TempData["message"] = "Successfully deleted the item.";
        return RedirectToAction("List", new { partnerId = item.PartnerID });
    }

    public IActionResult Update(int id)
    {
        var item = _context.Menu.Include(mi => mi.ItemCategory).FirstOrDefault(mi => mi.ItemID == id);
        if (item == null)
            return NotFound();

        ViewBag.MenuCategories = _context.MenuCategories.ToList();
        return View(item);
    }

    [HttpPost]
    public async Task<IActionResult> Update(Item item)
    {
        if (ModelState.IsValid)
        {
            _context.Menu.Update(item);
            await _context.SaveChangesAsync();
            return RedirectToAction("List", new { partnerId = item.PartnerID });
        }

        ViewBag.MenuCategories = _context.MenuCategories.ToList();
        return View(item);
    }
}
