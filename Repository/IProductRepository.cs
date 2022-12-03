using Microsoft.AspNetCore.Mvc;
using ProductsManagementAPI.Models;

namespace ProductsManagementAPI.Repository
{
    public interface IProductRepository
    {        
        Task<ActionResult<IEnumerable<Product>>> ListProducts();
        Task<ActionResult<Product>> ListProduct(int id);
        Task<ActionResult<Product>> AddProduct(Product product);
        ActionResult<bool> UpdateProduct(int id, Product product);
        Task<bool> RemoveProduct(int id);
    }
}
