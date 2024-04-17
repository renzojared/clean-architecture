using Microsoft.AspNetCore.Identity;
using NorthWind.Membership.Backend.AspNetIdentity.Resources;
using NorthWind.Membership.Entities.DTOs.UserRegistration;
using NorthWind.Validation.Entities.ValueObjects;

namespace NorthWind.Membership.Backend.AspNetIdentity.Services;

internal static class ErrorMessagesMapper
{
    public static IEnumerable<ValidationError> ToValidationErrors(this IEnumerable<IdentityError> errors)
    {
        List<ValidationError> result = [];
        foreach (var error in errors)
        {
            switch (error.Code)
            {
                case nameof(IdentityErrorDescriber.DuplicateUserName):
                    result.Add(new ValidationError(nameof(UserRegistrationDto.Email),
                        Messages.DuplicateUserNameErrorMessage));
                    break;
                default:
                    result.Add(new ValidationError(error.Code, error.Description));
                    break;
            }
        }

        return result;
    }
}