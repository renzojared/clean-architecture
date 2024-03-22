using NorthWind.Events.Interfaces;
using NorthWind.Events.Services;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyContainer
{
    public static IServiceCollection AddEventServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IDomainEventHub<>), typeof(DomainEventHub<>));
        return services;
    }
}