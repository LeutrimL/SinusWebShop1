using SinusWebShop.Client.Services;

namespace SinusWebShop
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();

            // Registrera en HTTP-klient för ProductService
            services.AddHttpClient<IProductService, ProductService>(client =>
            {
                client.BaseAddress = new Uri("https://dummyjson.com");
            });
        }
    }
}
