using NorthWind.Membership.Frontend.RazorViews;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyContainer
{
    public static IServiceCollection AddNorthWindSalesServices
    (this IServiceCollection services, Action<HttpClient> configureHttpClient,
        Action<HttpClient> configureMembershipHttpClient,
        Action<IHttpClientBuilder> configureHttpClientBuilder)
    {
        services
            .AddWebApiGateways(configureHttpClient, configureHttpClientBuilder)
            .AddViewsServices()
            .AddValidators()
            .AddValidationService()
            .AddMembershipServices(configureMembershipHttpClient);

        return services;
    }
}