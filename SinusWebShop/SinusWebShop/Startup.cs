namespace SinusWebShop
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient<ProductService>();

        }
    }

}
