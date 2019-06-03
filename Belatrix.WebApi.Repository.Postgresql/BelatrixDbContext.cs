using Belatrix.WebApi.Models;
using Belatrix.WebApi.Repository.Postgresql.configurations;
using Microsoft.EntityFrameworkCore;

namespace Belatrix.WebApi.Repository.Postgresql
{
    public class BelatrixDbContext : DbContext
    {

        public BelatrixDbContext(DbContextOptions<BelatrixDbContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Supplier> Supplier { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerConfig());
            modelBuilder.ApplyConfiguration(new OrderConfig());
            modelBuilder.ApplyConfiguration(new OrderItemConfig());
            modelBuilder.ApplyConfiguration(new ProductConfig());
            modelBuilder.ApplyConfiguration(new SuplierConfig());
        }
    }
}
