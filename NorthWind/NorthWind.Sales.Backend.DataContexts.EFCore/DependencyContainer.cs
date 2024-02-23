namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyContainer
{
    public static IServiceCollection AddDataContexts
        (this IServiceCollection services, Action<DBOptions> configureDBOptions)
    {
        services.Configure(configureDBOptions);
        services.AddScoped<INorthWindSalesCommandsDataContext, NorthWindSalesCommandsDataContext>();

        return services;
    }
}