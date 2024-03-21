using Newtonsoft.Json;

namespace SinusWebShop.Client.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("https://dummyjson.com/");
        }

        public async Task<List<Product>> GetProductsAsync(string category)
        {
            var response = await _httpClient.GetAsync($"products/category/{category}");

            if (response.IsSuccessStatusCode)
            {
                var productJson = await response.Content.ReadAsStringAsync();
                var products = JsonConvert.DeserializeObject<Root>(productJson);

                return products.Products;
            }
            else
            {
                Console.WriteLine($"Failed to get products: {response.StatusCode}");
                return null;
            }
        }

        public Task<List<Product>> GetAllProductsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetProductByIdAsync(int productId)
        {
            throw new NotImplementedException();
        }
    }
}
