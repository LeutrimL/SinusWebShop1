namespace SinusWebShop.Client.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetProductsAsync();
        Task<List<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int productId);
    }

}
