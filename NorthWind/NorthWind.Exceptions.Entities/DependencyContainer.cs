using NorthWind.Exceptions.Entities.ExceptionHandlers;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyContainer
{
    private static bool AddOrchestrator = true;
    public static IServiceCollection TryAddOrchestrator
        (this IServiceCollection services)
    {
        if (AddOrchestrator)
        {
            services.AddExceptionHandler<ExceptionHandlerOrchestrator>();
            AddOrchestrator = false;
        }

        return services;
    }

    public static IServiceCollection AddCustomExceptionHandler<ExceptionType, HandlerType>(
        this IServiceCollection services)
        where ExceptionType : Exception
        where HandlerType : class, IExceptionHandler<ExceptionType>
    {
        services.TryAddOrchestrator();
        services.AddKeyedSingleton<object, HandlerType>(typeof(IExceptionHandler<>));

        return services;
    }

    public static IServiceCollection AddValidationExceptionHandler(this IServiceCollection services)
    {
        services.AddCustomExceptionHandler<ValidationException, ValidationExceptionHandler>();
        return services;
    }
    
    public static IServiceCollection AddUpdateExceptionHandler(this IServiceCollection services)
    {
        services.AddCustomExceptionHandler<UpdateException, UpdateExceptionHandler>();
        return services;
    }
    
    public static IServiceCollection AddUnhandledExceptionHandler(this IServiceCollection services)
    {
        services.TryAddOrchestrator();
        services.AddExceptionHandler<UnhandledExceptionHandler>();
        return services;
    }
}