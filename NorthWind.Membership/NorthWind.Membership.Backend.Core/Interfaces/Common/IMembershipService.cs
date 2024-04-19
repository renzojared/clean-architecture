using NorthWind.Membership.Entities.DTOs.UserLogin;
using NorthWind.Membership.Entities.DTOs.UserRegistration;

namespace NorthWind.Membership.Backend.Core.Interfaces.Common;

public interface IMembershipService
{
    Task<Result<IEnumerable<ValidationError>>> Register(UserRegistrationDto userData);
    Task<UserDto> GetUserByCredentials(UserCredentialsDto userData);
}