namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyContainer
{
    public static IServiceCollection AddExceptionDelegatingHandler
        (this IServiceCollection services)
    {
        services.TryAddTransient<ExceptionDelegatingHandler>();
        return services;
    }
}