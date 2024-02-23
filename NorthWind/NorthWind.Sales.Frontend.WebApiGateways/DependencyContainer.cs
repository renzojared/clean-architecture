using NorthWind.Sales.Frontend.WebApiGateways;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyContainer
{
    public static IServiceCollection AddWebApiGateways
        (this IServiceCollection services, Action<HttpClient> configureHttpClient)
    {
        services.AddHttpClient<ICreateOrderGateway, CreateOrderGateway>(configureHttpClient);
        return services;
    }
}