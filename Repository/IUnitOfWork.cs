namespace ProductsManagementAPI.Repository
{
    public interface IUnitOfWork
    {
        IProductRepository Products { get; }
        Task CompleteAsync();
    }
}
