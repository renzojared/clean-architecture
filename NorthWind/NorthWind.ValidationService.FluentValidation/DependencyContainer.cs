using NorthWind.ValidationService.FluentValidation;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyContainer
{
    public static IServiceCollection AddValidationService(this IServiceCollection services)
    {
        services.AddScoped(typeof(IValidationService<>), typeof(FluentValidationService<>));
        return services;
    }
}