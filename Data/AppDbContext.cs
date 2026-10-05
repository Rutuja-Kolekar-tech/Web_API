using Microsoft.EntityFrameworkCore;
using Web_API_Project.Entities;

namespace Web_API_Project.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options):DbContext(options)
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
