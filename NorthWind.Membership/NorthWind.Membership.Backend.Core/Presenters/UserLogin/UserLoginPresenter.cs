namespace NorthWind.Membership.Backend.Core.Presenters.UserLogin;

internal class UserLoginPresenter(JwtService service) : IUserLoginOutputPort
{
    public IResult Result { get; private set; }

    public Task Handle(Result<UserDto, IEnumerable<ValidationError>> userLoginResult)
    {
        userLoginResult.HandleError(
            userDto => { Result = Results.Ok(new TokensDto(service.GetToken(userDto))); },
            errors =>
            {
                Result = Results.Problem(
                    errors.ToProblemDetails(
                        UserLoginMessages.UserLoginErrorTitle,
                        UserLoginMessages.UserLoginErrorDetail,
                        nameof(UserLoginPresenter)));
            }
        );
        return Task.CompletedTask;
    }
}