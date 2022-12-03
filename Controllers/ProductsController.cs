using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsManagementAPI.Models;
using ProductsManagementAPI.Repository;

namespace ProductsManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;

        public ProductsController(IUnitOfWork unitOfWork, ILogger logger) 
        { 
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            try 
            { 
                var products = await _unitOfWork.Products.ListProducts();
                return products;
            }
            catch (Exception ex)
            {
                _logger.LogTrace("Message: " + ex);
                return BadRequest(ex);
            }
            
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            try
            {
                var product = await _unitOfWork.Products.ListProduct(id);

                if (product == null)
                {
                    return NotFound();
                }
            

                return product;
            }
            catch (Exception ex)
            {
                _logger.LogTrace("Message: " + ex);
                return BadRequest(ex);
            }
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id > 0 && id != product.Id)
            {
                return BadRequest();
            }

            try
            {
                _unitOfWork.Products.UpdateProduct(id, product);
                await _unitOfWork.CompleteAsync();
            }
            catch (Exception ex)
            {
                _logger.LogTrace("Message: " + ex);
            }

            return NoContent();
        }

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult<Product> PostProduct(Product product)
       {
            if (product == null)
            {
                return BadRequest();
            }

            try
            {
                _unitOfWork.Products.AddProduct(product);
                _unitOfWork.CompleteAsync();
            }
            catch (Exception ex)
            {
                _logger.LogTrace("Message: " + ex);
            }

            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _unitOfWork.Products.ListProduct(id);

            if (product == null)
            {
                return NotFound();
            }

            try
            {
                await _unitOfWork.Products.RemoveProduct(id);
                await _unitOfWork.CompleteAsync();
            }
            catch (Exception ex)
            {
                _logger.LogTrace("Message: " + ex);
            }

            return NoContent();
        }
    }
}
