namespace SinusWebShop.Client.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetProductsAsync(string category);
        Task<List<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int productId);
    }
}
