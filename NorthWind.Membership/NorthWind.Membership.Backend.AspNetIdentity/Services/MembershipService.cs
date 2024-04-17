using Microsoft.AspNetCore.Identity;
using NorthWind.Membership.Backend.AspNetIdentity.Entities;
using NorthWind.Membership.Backend.Core.Interfaces.Common;
using NorthWind.Membership.Entities.DTOs.UserRegistration;
using NorthWind.Result.Entities;
using NorthWind.Validation.Entities.ValueObjects;

namespace NorthWind.Membership.Backend.AspNetIdentity.Services;

internal class MembershipService(UserManager<NorthWindUser> manager): IMembershipService
{
    public async Task<Result<IEnumerable<ValidationError>>> Register(UserRegistrationDto userData)
    {
        Result<IEnumerable<ValidationError>> result;

        var user = new NorthWindUser
        {
            UserName = userData.Email,
            Email = userData.Email,
            FirstName = userData.FirstName,
            Lastname = userData.LastName,
        };

        var createResult = await manager.CreateAsync(user, userData.Password);

        if (createResult.Succeeded)
            result = new Result<IEnumerable<ValidationError>>();
        else
            result = new Result<IEnumerable<ValidationError>>(createResult.Errors.ToValidationErrors());
        
        return result;
    }
}