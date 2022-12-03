using ProductsManagementAPI.Data;

namespace ProductsManagementAPI.Repository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ProductDbContext _context;
        public IProductRepository Products { get; private set; }

        public UnitOfWork(ProductDbContext context)
        {
            _context = context;
            Products = new ProductRepository(_context);
        }

        public void Dispose()
        {
            try 
            { 
                _context.Dispose();
            }
            catch { }
        }

        public async Task CompleteAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.StackTrace);
                Console.ReadLine();
            }
        }
    }
}
