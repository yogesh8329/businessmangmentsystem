using Microsoft.EntityFrameworkCore;
using BMS.Core.Entities;

namespace BMS.Api.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users => Set<User>();
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }



    }
}
