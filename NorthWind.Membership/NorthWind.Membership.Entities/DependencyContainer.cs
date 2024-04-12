using NorthWind.Membership.Entities.DTOs.UserRegistration;
using NorthWind.Membership.Entities.Validators.UserRegistration;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyContainer
{
    public static IServiceCollection AddMembershipValidators(this IServiceCollection services)
    {
        services.AddModelValidator<UserRegistrationDto, UserRegistrationDtoValidator>();
        return services;
    }
}