using Microsoft.Extensions.DependencyInjection;
using NorthWind.HttpDelegatingHandlers;
using NorthWind.Membership.Frontend.RazorViews.ViewModels.UserRegistration;
using NorthWind.Membership.Frontend.RazorViews.WebApiGateways;

namespace NorthWind.Membership.Frontend.RazorViews;

public static class DependencyContainer
{
    public static IServiceCollection AddMembershipServices(this IServiceCollection services,
        Action<HttpClient> configureHttpClient)
    {
        services.AddExceptionDelegatingHandler();
        services.AddHttpClient<MembershipGateway>(configureHttpClient)
            .AddHttpMessageHandler<ExceptionDelegatingHandler>();
        services.AddScoped<UserRegistrationViewModel>();
        services.AddMembershipValidators();
        services.AddModelValidator<UserRegistrationViewModel, UserRegistrationViewModelDtoValidator>();
        services.AddModelValidator<UserRegistrationViewModel, UserRegistrationViewModelValidator>();

        return services;
    }
}