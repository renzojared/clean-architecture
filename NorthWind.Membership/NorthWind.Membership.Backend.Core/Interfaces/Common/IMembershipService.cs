using NorthWind.Membership.Entities.DTOs.UserRegistration;
using NorthWind.Result.Entities;
using NorthWind.Validation.Entities.ValueObjects;

namespace NorthWind.Membership.Backend.Core.Interfaces.Common;

public interface IMembershipService
{
    Task<Result<IEnumerable<ValidationError>>> Register(UserRegistrationDto userData);
}