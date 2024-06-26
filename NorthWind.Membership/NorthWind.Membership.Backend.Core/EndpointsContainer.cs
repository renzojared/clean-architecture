namespace Microsoft.AspNetCore.Builder;

public static class EndpointsContainer
{
    public static WebApplication UserMembershipEndpoints(this WebApplication app)
    {
        app.UseUserRegistrationController();
        app.UserUserLoginController();
        return app;
    }
}