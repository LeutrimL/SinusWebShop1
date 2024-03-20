using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SinusWebShop.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped<IProductService, ProductService>();

await builder.Build().RunAsync();
