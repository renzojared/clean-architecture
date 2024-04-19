using NorthWind.Membership.Backend.Core.Interfaces.UserLogin;

namespace NorthWind.Membership.Backend.Core.Presenters.UserLogin;

public class UserLoginPresenter : IUserLoginOutputPort
{
    public IResult Result { get; }
    public Task Handle(Result<UserDto, IEnumerable<ValidationError>> userLoginResult)
    {
        //TODO Implement
        throw new NotImplementedException();
    }
}