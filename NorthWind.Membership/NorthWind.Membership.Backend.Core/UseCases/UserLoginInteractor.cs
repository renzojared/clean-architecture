namespace NorthWind.Membership.Backend.Core.UseCases;

internal class UserLoginInteractor(
    IUserLoginOutputPort presenter,
    IMembershipService membershipService,
    IModelValidatorHub<UserCredentialsDto> validationService) : IUserLoginInputPort
{
    public async Task Handle(UserCredentialsDto userData)
    {
        Result<UserDto, IEnumerable<ValidationError>> result;

        if (!await validationService.Validate(userData))
            result = new(validationService.Errors);
        else
        {
            var user = await membershipService.GetUserByCredentials(userData);
            if (user is null)
            {
                result = new([
                    new ValidationError(nameof(userData.Password), UserLoginMessages.InvalidUserCredentialsErrorMessage)
                ]);
            }
            else
                result = new(user);
        }

        await presenter.Handle(result);
    }
}