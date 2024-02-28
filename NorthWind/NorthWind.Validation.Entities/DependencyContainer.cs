namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyContainer
{
    public static IServiceCollection AddDefaultModelValidatorHub(this IServiceCollection services)
    {
        services.TryAddScoped(typeof(IModelValidator<>), typeof(ModelValidatorHub<>));
        return services;
    }

    public static IServiceCollection AddModelValidator<ModelType, ModelValidatorType>(
        this IServiceCollection services) where ModelValidatorType : class, IModelValidator<ModelType>
    {
        services.AddDefaultModelValidatorHub();
        services.AddScoped<IModelValidator<ModelType>, ModelValidatorType>();
        return services;
    }
}