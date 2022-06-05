using LCWTest.Models;
using Microsoft.EntityFrameworkCore;

namespace LCWTest.Context
{
    public class LCWDbContext : DbContext
    {
        public LCWDbContext(DbContextOptions options)
           : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CustomerOrder> CustomerOrders { get; set; }
    }
}
