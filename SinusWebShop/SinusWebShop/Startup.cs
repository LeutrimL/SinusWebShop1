using SinusWebShop.Client.Services;

namespace SinusWebShop
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();

        }
    }
}
