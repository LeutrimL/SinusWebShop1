using System.Text.Json;

namespace SinusWebShop.Client.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            var response = await _httpClient.GetAsync("/products");

            if (response.IsSuccessStatusCode)
            {
                var productJson = await response.Content.ReadAsStringAsync();
                var productResponse = JsonSerializer.Deserialize<ProductResponse>(productJson);
                return productResponse.Products;
            }
            else
            {
                Console.WriteLine($"Failed to get products: {response.StatusCode}");
                return null;
            }
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await GetProductsAsync();
        }

        public async Task<Product> GetProductByIdAsync(int productId)
        {
            var response = await _httpClient.GetAsync($"/products/{productId}");

            if (response.IsSuccessStatusCode)
            {
                var productJson = await response.Content.ReadAsStringAsync();
                var product = JsonSerializer.Deserialize<Product>(productJson);
                return product;
            }
            else
            {
                Console.WriteLine($"Failed to get product with ID {productId}: {response.StatusCode}");
                return null;
            }
        }
    }
}
