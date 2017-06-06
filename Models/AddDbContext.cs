using Microsoft.EntityFrameworkCore;

namespace OnlineShop.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Tour> Tours { get; set; }
        
    }
}