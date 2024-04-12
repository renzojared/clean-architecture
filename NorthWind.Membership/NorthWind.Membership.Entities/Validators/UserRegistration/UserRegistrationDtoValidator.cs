using NorthWind.Membership.Entities.DTOs.UserRegistration;
using NorthWind.Membership.Entities.Resources;
using NorthWind.Validation.Entities.Abstractions;
using NorthWind.Validation.Entities.Enums;
using NorthWind.Validation.Entities.Interfaces;

namespace NorthWind.Membership.Entities.Validators.UserRegistration;

internal class UserRegistrationDtoValidator : AbstractModelValidator<UserRegistrationDto>
{
    public UserRegistrationDtoValidator(IValidationService<UserRegistrationDto> validationService)
        : base(validationService)
    {
        AddRuleFor(s => s.FirstName)
            .NotEmpty(UserRegistrationMessages.RequiredFirstNameErrorMessage);
        AddRuleFor(s => s.LastName)
            .NotEmpty(UserRegistrationMessages.RequiresLastNameErrorMessage);
        AddRuleFor(s => s.Email)
            .NotEmpty(UserRegistrationMessages.RequiredEmailErrorMessage)
            .EmailAddress(UserRegistrationMessages.InvalidEmailErrorMessage);
        AddRuleFor(s => s.Password)
            .StopOnFirstFailure()
            .NotEmpty(UserRegistrationMessages.RequiredPasswordErrorMessage)
            .MinimumLength(6, UserRegistrationMessages.PasswordTooShortErrorMessage)
            .Must(s =>
                s.Any(c => char.IsLower(c)), UserRegistrationMessages.PasswordRequiresLowerErrorMessage)
            .Must(s =>
                s.Any(c => char.IsUpper(c)), UserRegistrationMessages.PasswordRequiresUpperErrorMessage)
            .Must(s =>
                s.Any(c => char.IsDigit(c)), UserRegistrationMessages.PasswordRequiresDigitErrorMessage)
            .Must(s =>
                s.Any(c => char.IsLetter(c)), UserRegistrationMessages.PasswordRequiresNonAlphanumericErrorMessage);
    }
}