using Microsoft.EntityFrameworkCore;
using Vehicle_Hub.Models;

namespace Vehicle_Hub.Data
{
    public class CarDbContext : DbContext
    {
        public CarDbContext(DbContextOptions options) : base(options)
        {
        }
        // Define DbSet properties for my models... like tables on my sql databse
        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }

    }
}
