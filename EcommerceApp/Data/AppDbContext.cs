using EcommerceApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EcommerceApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product_Customer>().HasKey(productCustomer => new
            {
                productCustomer.ProductId,
                productCustomer.CustomerId
            });

            modelBuilder.Entity<Product_Customer>().HasOne(c => c.Product).WithMany(productCustomer => productCustomer.Products_Customers).HasForeignKey(c => c.ProductId);

            modelBuilder.Entity<Product_Customer>().HasOne(p => p.Customer).WithMany(productCustomer => productCustomer.Products_Customers).HasForeignKey(p => p.CustomerId);

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Product_Customer> Products_Customers { get; set; }
    }
}
