using Microsoft.EntityFrameworkCore;

namespace UberEats.Models
{
    public class UberContext : DbContext
    {
        public UberContext(DbContextOptions<UberContext> options)
            : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        public DbSet<Driver> Drivers { get; set; } = null!;
        public DbSet<Partner> Partners { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Driver>().HasData(
                new Driver { DriverID = 1, Name = "Restaurent" },
                new Driver { DriverID = 2, Name = "Grocery" },
                new Driver { DriverID = 3, Name = "Alcohol" },
                new Driver {DriverID=4, Name="Convienience"},
                new Driver {DriverID=5, Name="Flower shop"},
                new Driver {DriverID=6,Name="Pet Store"},
                new Driver {DriverID=7,Name="retail"}
            );

            modelBuilder.Entity<Partner>().HasData(
                new Partner
                {
                    PartnerID = 1, 
                    DriverID = 1,
                    BusinessName = "intial",
                    BusinessAddress = "Chicago, 3001",
                    BusinessEmail = "intial@gmail.com",
                    BusinessPhone = "123456"
                },
                new Partner
                {
                    PartnerID = 2,
                    DriverID = 1,
                    BusinessName = "apple",
                    BusinessAddress = "401 North",
                    BusinessEmail = "apple@gmail.com",
                    BusinessPhone = "234234"
                }
            );
        }
    }
}