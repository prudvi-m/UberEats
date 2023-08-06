using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace UberEats.Models
{
    public class UberContext : IdentityDbContext<User>
    {
        public UberContext(DbContextOptions<UberContext> options)
            : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Partner> Partners { get; set; } = null!;
        public DbSet<Driver> Drivers { get; set; } = null!;
        public DbSet<ItemCategory> MenuCategories { get; set; } = null!;
        public DbSet<Item> Menu { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryID = 1, Name = "Restaurant" },
                new Category { CategoryID = 2, Name = "Grocery" },
                new Category { CategoryID = 3, Name = "Alcohol" },
                new Category { CategoryID= 4, Name = "Convienience"},
                new Category { CategoryID= 5, Name = "Flower shop"},
                new Category { CategoryID= 6,Name = "Pet Store"},
                new Category { CategoryID= 7,Name = "retail"}
            );

            modelBuilder.Entity<ItemCategory>().HasData(
                new ItemCategory { ItemCategoryID = 1, Name = "Appetizer" },
                new ItemCategory { ItemCategoryID = 2, Name = "Soup" },
                new ItemCategory { ItemCategoryID = 3, Name = "Salad" },
                new ItemCategory { ItemCategoryID= 4, Name = "Main Course"},
                new ItemCategory { ItemCategoryID= 5, Name = "Dessert"},
                new ItemCategory { ItemCategoryID= 6,Name = "Drink"},
                new ItemCategory { ItemCategoryID= 7,Name = "Vegetarian"}
            );

            modelBuilder.Entity<Item>().HasData(
                new Item {
                    ItemID = 1,
                    PartnerID = 1,
                    Name = "Biscochitos",
                    Price = 31.5,
                    Description = "Mast Brothers bittersweet chocolate",
                    ItemCategoryID = 5
                }
            );


            modelBuilder.Entity<Partner>().HasData(
                new Partner
                {
                    PartnerID = 1,
                    CategoryID = 1,
                    BusinessName = "Vinod Restaurant",
                    BusinessAddress = "Chicago, 401, West Downtown",
                    BusinessEmail = "vr@gmail.com",
                    BusinessPhone = "007"
                },new Partner
                {
                    PartnerID = 2,
                    CategoryID = 2,
                    BusinessName = "AdventureQuest Tours",
                    BusinessAddress = "Dallas, 401, East Downtown",
                    BusinessEmail = "vr@gmail.com",
                    BusinessPhone = "007"
                },new Partner
                {
                    PartnerID = 3,
                    CategoryID = 3,
                    BusinessName = "CodeCraft Solutions",
                    BusinessAddress = "Illinios, 402",
                    BusinessEmail = "CodeCraft@gmail.com",
                    BusinessPhone = "007"
                },new Partner
                {
                    PartnerID = 4,
                    CategoryID = 2,
                    BusinessName = "DecoCraft Interiors",
                    BusinessAddress = "Texas, 403",
                    BusinessEmail = "DecoCraft@gmail.com",
                    BusinessPhone = "007"
                },new Partner
                {
                    PartnerID = 5,
                    CategoryID = 1,
                    BusinessName = "Vinod Restaurant",
                    BusinessAddress = "Chicago, 401, West Downtown",
                    BusinessEmail = "vr@gmail.com",
                    BusinessPhone = "007"
                },new Partner
                {
                    PartnerID = 6,
                    CategoryID = 3,
                    BusinessName = "Vinod Restaurant",
                    BusinessAddress = "Chicago, 401, West Downtown",
                    BusinessEmail = "vr@gmail.com",
                    BusinessPhone = "007"
                }
            );
        }
    }
}