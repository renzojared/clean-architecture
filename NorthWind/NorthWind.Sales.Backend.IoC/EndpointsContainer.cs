namespace Microsoft.AspNetCore.Builder;

public static class EndpointsContainer
{
    public static WebApplication MapNorthWindSalesEndpoints(this WebApplication app)
    {
        app.UseCreateOrderController();
        app.UserMembershipEndpoints();
        return app;
    }
}