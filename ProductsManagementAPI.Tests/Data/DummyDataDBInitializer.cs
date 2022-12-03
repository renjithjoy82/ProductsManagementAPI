using Microsoft.Extensions.Hosting;
using ProductsManagementAPI.Data;
using ProductsManagementAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsManagementAPI.Tests.Data
{
    public class DummyDataDBInitializer
    {
        public DummyDataDBInitializer()
        {
        }

        public void Seed(ProductDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            context.Products.AddRange(
                new Product() { Name = "Harry Potter", Price = 100, ProductTypeId = 1, Active = true },
                new Product() { Name = "Pleasant Sun", Price = 50, ProductTypeId = 1, Active = true },
                new Product() { Name = "IPhone 13", Price = 1550, ProductTypeId = 2, Active = true },
                new Product() { Name = "Samsung Galaxy S 22", Price = 1650, ProductTypeId = 2, Active = true }
            );
            context.ProductTypes.AddRange(
                new ProductType() { ProductTypeName = "Books" },
                new ProductType() { ProductTypeName = "Electronics" }
            );
            context.SaveChanges();
        }
    }
}
