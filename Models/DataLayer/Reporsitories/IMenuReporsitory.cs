using Microsoft.EntityFrameworkCore;

namespace UberEats.Models.DataLayer.Reporsitories
{
    public interface IMenuReporsitory: IDisposable
    {

        IEnumerable<Item> MenuItemsbycatgeoryID(int? PartnerId, int? categoryID);

        IEnumerable<Item> MenuItems(int? PartnerId);

        Item GetMenuItembyID(int? id);
        Partner GetPartnerbyID(int? id);


        IEnumerable<ItemCategory> MenuCategories();


        void DeleteItem(int itemID);
        void UpdateItem(Item menuItem);

        void AddItem(Item menuItem);

        void Save();

    }

}
