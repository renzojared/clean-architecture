using NorthWind.Membership.Entities.DTOs.UserLogin;

namespace NorthWind.Membership.Backend.Core.Interfaces.UserLogin;

internal interface IUserLoginInputPort
{
    Task Handle(UserCredentialsDto userData);
}