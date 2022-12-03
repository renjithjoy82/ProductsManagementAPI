using Microsoft.EntityFrameworkCore;
using ProductsManagementAPI.Models;

namespace ProductsManagementAPI.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductType> ProductTypes { get; set; }
        public object Product { get; set; }
    }
}
