using Newtonsoft.Json;

namespace SinusWebShop.Client.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _httpClient.BaseAddress = new Uri("https://dummyjson.com/");
        }

        public async Task<List<Product>> GetProductsAsync(string category)
        {
            var response = await _httpClient.GetAsync($"products/category/{category}");

            if (response.IsSuccessStatusCode)
            {
                var productJson = await response.Content.ReadAsStringAsync();
                var products = JsonConvert.DeserializeObject<List<Product>>(productJson);
                return products;
            }
            else
            {
                Console.WriteLine($"Failed to get products: {response.StatusCode}");
                return null;
            }
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            var response = await _httpClient.GetAsync("products/all");

            if (response.IsSuccessStatusCode)
            {
                var productJson = await response.Content.ReadAsStringAsync();
                var products = JsonConvert.DeserializeObject<List<Product>>(productJson);
                return products;
            }
            else
            {
                Console.WriteLine($"Failed to get all products: {response.StatusCode}");
                return null;
            }
        }

        public async Task<Product> GetProductByIdAsync(int productId)
        {
            var response = await _httpClient.GetAsync($"products/{productId}");

            if (response.IsSuccessStatusCode)
            {
                var productJson = await response.Content.ReadAsStringAsync();
                var product = JsonConvert.DeserializeObject<Product>(productJson);
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
