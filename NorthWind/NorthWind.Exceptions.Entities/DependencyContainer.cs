using NorthWind.Exceptions.Entities.ExceptionHandlers;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyContainer
{
    public static IServiceCollection AddValidationExceptionHandler(this IServiceCollection services)
    {
        services.AddExceptionHandler<ValidationExceptionHandler>();
        return services;
    }
    
    public static IServiceCollection AddUpdateExceptionHandler(this IServiceCollection services)
    {
        services.AddExceptionHandler<UpdateExceptionHandler>();
        return services;
    }
    
    public static IServiceCollection AddUnauthorizedAccessExceptionHandler(this IServiceCollection services)
    {
        services.AddExceptionHandler<UnauthorizedAccessExceptionHandler>();
        return services;
    }
    
    public static IServiceCollection AddUnhandledExceptionHandler(this IServiceCollection services)
    {
        services.AddExceptionHandler<UnhandledExceptionHandler>();
        return services;
    }
}