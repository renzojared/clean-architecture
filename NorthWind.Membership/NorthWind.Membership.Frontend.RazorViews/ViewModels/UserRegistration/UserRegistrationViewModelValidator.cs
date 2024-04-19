using NorthWind.Membership.Frontend.RazorViews.Resources;
using NorthWind.Validation.Entities.Abstractions;
using NorthWind.Validation.Entities.Enums;
using NorthWind.Validation.Entities.Interfaces;

namespace NorthWind.Membership.Frontend.RazorViews.ViewModels.UserRegistration;

public class UserRegistrationViewModelValidator : AbstractModelValidator<UserRegistrationViewModel>
{
    public UserRegistrationViewModelValidator(IValidationService<UserRegistrationViewModel> validationService,
        ValidationConstraint constraint = ValidationConstraint.AlwaysValidate) : base(validationService, constraint)
    {
        AddRuleFor(s => s.PasswordConfirmation)
            .Equal(s => s.Password, UserRegistrationMessages.ConfirmPasswordErrorMessage);
    }
}