using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsManagementAPI.Data;
using ProductsManagementAPI.Models;

namespace ProductsManagementAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _context;

        public ProductRepository(ProductDbContext context)
        {
            _context = context;
        }               

        public async Task<ActionResult<Product>> ListProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return null;
            }

            return product;
        }

        public async Task<ActionResult<IEnumerable<Product>>> ListProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<ActionResult<Product>> AddProduct(Product product)
        {
            _context.Products.Add(product);
            return product;
        }

        public ActionResult<bool> UpdateProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return false;
            }

            _context.Entry(product).State = EntityState.Modified;

            return true;
        }

        public async Task<bool> RemoveProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return false;
            }

            _context.Products.Remove(product);

            return true;
        }
    }
}
