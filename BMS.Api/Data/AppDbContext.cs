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
    }
}
