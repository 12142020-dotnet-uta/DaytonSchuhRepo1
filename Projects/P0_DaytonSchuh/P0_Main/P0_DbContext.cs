using Microsoft.EntityFrameworkCore;

namespace P0_DaytonSchuh1
{
    public class P0_DbContext : DbContext
    {
        public DbSet<Customer> customers { get; set; }
        public DbSet<Order> orders { get; set; }
        public DbSet<Location> locations { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<LocationLine> locationLines { get; set; }
        public DbSet<OrderLine> orderLines { get; set; }

        public P0_DbContext() { }
        public P0_DbContext(DbContextOptions<P0_DbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
                options.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=RiskyBusiness;Trusted_Connection=True;");
        }
    }
}