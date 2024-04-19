using NorthWind.Membership.Backend.Core.Interfaces.Common;
using NorthWind.Membership.Backend.Core.Interfaces.UserRegistration;
using NorthWind.Membership.Entities.DTOs.UserRegistration;
using NorthWind.Validation.Entities.Interfaces;

namespace NorthWind.Membership.Backend.Core.UseCases;

internal class UserRegistrationInteractor(
    IMembershipService membershipService,
    IUserRegistrationOutputPort presenter,
    IModelValidatorHub<UserRegistrationDto> validationService
    ) : IUserRegistrationInputPort
{
    public async Task Handle(UserRegistrationDto userData)
    {
        Result<IEnumerable<ValidationError>> result;

        if (await validationService.Validate(userData))
            result = await membershipService.Register(userData);
        else
            result = new Result<IEnumerable<ValidationError>>(validationService.Errors);

        await presenter.Handle(result);
    }
}