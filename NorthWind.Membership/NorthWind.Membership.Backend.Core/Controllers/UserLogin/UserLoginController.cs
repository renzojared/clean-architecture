namespace Microsoft.AspNetCore.Builder;

internal static class UserLoginController
{
    public static WebApplication UserUserLoginController(this WebApplication app)
    {
        app.MapPost(Endpoints.Login,
            async (UserCredentialsDto userCredentialsDto, IUserLoginInputPort inputPort,
                IUserLoginOutputPort presenter) =>
            {
                await inputPort.Handle(userCredentialsDto);
                return presenter.Result;
            });

        return app;
    }
}