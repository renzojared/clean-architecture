using NorthWind.Membership.Backend.Core.Interfaces.UserRegistration;
using NorthWind.Membership.Entities.DTOs.UserRegistration;

namespace Microsoft.AspNetCore.Builder;

internal static class UserRegistrationController
{
    public static WebApplication UseUserRegistrationController(this WebApplication app)
    {
        app.MapPost(Endpoints.Register,
            async (UserRegistrationDto userData,
                IUserRegistrationInputPort inputPort,
                IUserRegistrationOutputPort presenter) =>
            {
                await inputPort.Handle(userData);
                return presenter.Result;
            });
        
        return app;
    }
}