using NorthWind.Membership.Entities.DTOs.UserRegistration;
using NorthWind.Validation.Entities.Abstractions;
using NorthWind.Validation.Entities.Enums;
using NorthWind.Validation.Entities.Interfaces;

namespace NorthWind.Membership.Frontend.RazorViews.ViewModels.UserRegistration;

internal class UserRegistrationViewModelDtoValidator(IModelValidatorHub<UserRegistrationDto> validator)
    : AbstractViewModelValidator<UserRegistrationDto, UserRegistrationViewModel>(validator,
        ValidationConstraint.ValidateIfThereAreNoPreviousErrors)
{
}