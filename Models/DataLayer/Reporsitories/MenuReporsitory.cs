using Microsoft.EntityFrameworkCore;

namespace UberEats.Models.DataLayer.Reporsitories
{
    
    public class MenuReporsitory : IMenuReporsitory, IDisposable
    {

        private UberContext context;
        public MenuReporsitory(UberContext context)
        {this.context = context;}

        public IEnumerable<Item> MenuItems(int? id)
        {
            return context.Menu
                .Where(x => x.PartnerID == id)
                .ToList();
        }
        public IEnumerable<Item> MenuItemsbycatgeoryID(int? id, int? categoryID)
        {
            return context.Menu
                .Where(x => x.PartnerID == id && x.ItemCategoryID == categoryID)
                .ToList();
        }


        public IEnumerable<ItemCategory> MenuCategories()
        {
            return context.MenuCategories
                .ToList();
        }

        public Item GetMenuItembyID(int? id)
        {
            return context.Menu
                .Where(x => x.ItemID == id)
                .FirstOrDefault();
        }

        public void DeleteItem(int id)
        {
            Item menuItem = context.Menu.Find(id);
            context.Menu
                .Remove(menuItem);
        }

        public Partner GetPartnerbyID(int? id)
        {
            return context.Partners
                .Where(x => x.PartnerID == id)
                .FirstOrDefault();
        }

        public void AddItem(Item menuItem)
        {
            context.Menu
                .Add(menuItem);
        }
        public void UpdateItem(Item menuItem)
        {
            context
                .Entry(menuItem).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }
        private bool disposed = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        
    }
}
