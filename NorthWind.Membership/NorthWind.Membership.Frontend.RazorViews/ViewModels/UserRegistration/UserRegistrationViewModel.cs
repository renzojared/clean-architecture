using NorthWind.Membership.Entities.DTOs.UserRegistration;
using NorthWind.Membership.Frontend.RazorViews.Resources;
using NorthWind.Membership.Frontend.RazorViews.WebApiGateways;
using NorthWind.RazorComponents.Validators;
using NorthWind.Validation.Entities.Interfaces;
using NorthWind.Validation.Entities.ValueObjects;

namespace NorthWind.Membership.Frontend.RazorViews.ViewModels.UserRegistration;

public class UserRegistrationViewModel(MembershipGateway gateway, IModelValidatorHub<UserRegistrationViewModel> validator)
{
    public IModelValidatorHub<UserRegistrationViewModel> Validator => validator;
    public ModelValidator<UserRegistrationViewModel> ModelValidatorComponentReference { get; set; }
    public string InformationMessage { get; private set; }
    
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string PasswordConfirmation { get; set; }

    public async Task Register()
    {
        try
        {
            InformationMessage = "";

            await gateway.RegisterAsync((UserRegistrationDto) this);
            InformationMessage = UserRegistrationMessages.RegisteredUserMessage;
        }
        catch (HttpRequestException e)
        {
            if (e.Data.Contains("Errors"))
            {
                var errors = e.Data["Errors"] as IEnumerable<ValidationError>;
                ModelValidatorComponentReference.AddErrors(errors);
            }
            else
            {
                throw;
            }
        }
    }

    public static explicit operator UserRegistrationDto(UserRegistrationViewModel model)
        => new(model.Email, model.Password, model.FirstName, model.LastName);
}