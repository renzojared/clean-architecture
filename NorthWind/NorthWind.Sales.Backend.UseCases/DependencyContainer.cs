namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyContainer
{
    public static IServiceCollection AddUseCasesServices(this IServiceCollection services)
    {
        services.AddScoped<ICreateOrderInputPort, CreateOrderInteractor>();
        services.AddModelValidator<CreateOrderDto, CreateOrderCustomerValidator>();
        services.AddModelValidator<CreateOrderDto, CreateOrderProductValidator>(); 

        return services;
    }
}