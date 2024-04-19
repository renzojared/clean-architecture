using NorthWind.Membership.Entities.DTOs.UserLogin;
using NorthWind.Membership.Entities.Resources;

namespace NorthWind.Membership.Entities.Validators.UserLogin;

internal class UseCredentialsDtoValidator : AbstractModelValidator<UserCredentialsDto>
{
    public UseCredentialsDtoValidator(IValidationService<UserCredentialsDto> validationService, ValidationConstraint constraint = ValidationConstraint.AlwaysValidate) : base(validationService, constraint)
    {
        AddRuleFor(s => s.Email)
            .NotEmpty(UserLoginMessages.RequiredEmailErrorMessage)
            .EmailAddress(UserLoginMessages.InvalidEmailErrorMessage);

        AddRuleFor(s => s.Password)
            .NotEmpty(UserLoginMessages.RequiredPasswordErrorMessage);
    }
}