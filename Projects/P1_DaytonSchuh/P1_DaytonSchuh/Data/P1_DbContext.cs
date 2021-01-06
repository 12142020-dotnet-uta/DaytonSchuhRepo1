using Microsoft.EntityFrameworkCore;
using ModelLayer;
using P1_DaytonSchuh.Models;

namespace P1_DaytonSchuh.Data
{
    public class P1_DbContext : DbContext
    {
        public P1_DbContext(){}

        public P1_DbContext(DbContextOptions<P1_DbContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Product { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Customer> Customer { get; set; }
    }
}
