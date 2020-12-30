using Microsoft.EntityFrameworkCore;

namespace P0_DaytonSchuh
{
    public class StoreDbContext : DbContext
    {
        public DbSet<Customer> customers { get; set; }
        public DbSet<Location> locations { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<Inventory> inventories { get; set; }

        public DbSet<OrderLog> orderLogs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=RiskyBusiness;Trusted_Connection=True;");
        }
    }
}