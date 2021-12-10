using Microsoft.EntityFrameworkCore;
using BikeRent.DAL.Entity;

namespace BikeRent.DAL.EF
{
    public class BikeRentContext : DbContext
    {
        public DbSet<BikeType> BikeTypes { get; set; }
        public DbSet<Bike> Bikes { get; set; }

        public BikeRentContext(DbContextOptions<BikeRentContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
