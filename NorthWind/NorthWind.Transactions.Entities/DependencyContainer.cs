using NorthWind.Transactions.Entities.Interfaces;
using NorthWind.Transactions.Entities.Services;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyContainer
{
    public static IServiceCollection AddWindowsTransactionServices(this IServiceCollection services)
    {
        services.AddScoped<IDomainTransaction, DomainTransaction>();
        return services;
    }
}