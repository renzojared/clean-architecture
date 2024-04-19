namespace NorthWind.Membership.Backend.Core.Interfaces.UserLogin;

internal interface IUserLoginOutputPort
{
    IResult Result { get; }
    Task Handle(Result<UserDto, IEnumerable<ValidationError>> userLoginResult);
}