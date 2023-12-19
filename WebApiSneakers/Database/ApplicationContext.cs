using Microsoft.EntityFrameworkCore;
using WebApiSneakers.Models;

namespace WebApiSneakers.Database
{
    public class ApplicationContext: DbContext
    {
        public DbSet<Product>? Products { get; set; }
        public DbSet<User>? Users { get; set; }
        public DbSet<Favorite>? Favorites { get; set; }
        public DbSet<Order>? Orders { get; set; }
        public DbSet<ChangePrice>? ChangePrices { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
