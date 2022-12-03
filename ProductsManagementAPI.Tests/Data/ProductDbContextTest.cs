using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ProductsManagementAPI.Data;
using ProductsManagementAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsManagementAPI.Tests.Data
{
    public class ProductDbContextTest
    {
        

        public static DbContextOptions<ProductDbContext> dbContextOptions { get; }
        public static string connectionString = "Server=localhost;Database=ProductsManagementDB;UID=sa;PWD=Renjith123;";
                
        static ProductDbContextTest()
        {
            dbContextOptions = new DbContextOptionsBuilder<ProductDbContext>()
                .UseSqlServer(connectionString)
            .Options;
        }

        public ProductDbContextTest()
        {
            var context = new ProductDbContext(dbContextOptions);
            DummyDataDBInitializer db = new DummyDataDBInitializer();
            db.Seed(context);
        }
    }
}
