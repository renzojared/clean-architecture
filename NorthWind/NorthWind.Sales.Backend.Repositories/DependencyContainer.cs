using NorthWind.DomainLogs.Entities.Interfaces;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyContainer
{
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<ICommandsRepository, CommandsRepository>();
        services.AddScoped<IQueriesRepository, QueriesRepository>();
        services.AddScoped<IDomainLogsRepository, DomainLogsRepository>();

        return services;
    }
}