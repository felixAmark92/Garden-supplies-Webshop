using Labb2WebbTemplate.App.Services;

namespace Labb2WebbTemplate.App.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddAppServices(this IServiceCollection service)
    {
        service
            .AddScoped<RegionService>()
            .AddScoped<CityService>()
            .AddScoped<UserService>()
            .AddScoped<CategoryService>()
            .AddScoped<ProductService>()
            .AddScoped<CartService>()
            .AddScoped<OrderService>();
        return service;
    }
}