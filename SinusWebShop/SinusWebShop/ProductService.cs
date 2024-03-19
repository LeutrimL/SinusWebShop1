using System.Text.Json;

namespace SinusWebShop
{
    public class ProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("https://dummyjson.com/products");

                if (response.IsSuccessStatusCode)
                {
                    var productJson = await response.Content.ReadAsStringAsync();
                    var productResponse = JsonSerializer.Deserialize<ProductResponse>(productJson);
                    return productResponse.Products;
                }
                else
                {
                    Console.WriteLine($"Failed to get products: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception when calling API: {ex.Message}");
            }

            return null;
        }





    }

}
