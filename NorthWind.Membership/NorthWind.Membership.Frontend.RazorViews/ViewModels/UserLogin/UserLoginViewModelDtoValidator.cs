using NorthWind.Membership.Entities.DTOs.UserLogin;
using NorthWind.Validation.Entities.Abstractions;
using NorthWind.Validation.Entities.Enums;
using NorthWind.Validation.Entities.Interfaces;

namespace NorthWind.Membership.Frontend.RazorViews.ViewModels.UserLogin;

internal class UserLoginViewModelDtoValidator(IModelValidatorHub<UserCredentialsDto> validator)
    : AbstractViewModelValidator<UserCredentialsDto, UserLoginViewModel>(validator, ValidationConstraint.AlwaysValidate)
{
}