using NorthWind.Membership.Entities.DTOs.UserLogin;
using NorthWind.Membership.Frontend.RazorViews.AuthenticationStateProviders;
using NorthWind.Membership.Frontend.RazorViews.WebApiGateways;
using NorthWind.RazorComponents.Validators;
using NorthWind.Validation.Entities.Interfaces;
using NorthWind.Validation.Entities.ValueObjects;

namespace NorthWind.Membership.Frontend.RazorViews.ViewModels.UserLogin;

public class UserLoginViewModel(MembershipGateway gateway,
    IModelValidatorHub<UserLoginViewModel> validator,
    JwtAuthenticationStateProvider authenticationStateProvider)
{
    public IModelValidatorHub<UserLoginViewModel> Validator => validator;
    public ModelValidator<UserLoginViewModel> ModelValidatorComponentReference { get; set; }
    public event Action OnLogin;
    public string Email { get; set; }
    public string Password { get; set; }

    public async Task Login()
    {
        try
        {
            var tokens = await gateway.LoginAsync((UserCredentialsDto)this);
            await authenticationStateProvider.LoginAsync(tokens);

            OnLogin?.Invoke();
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
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public static explicit operator UserCredentialsDto(UserLoginViewModel model)
        => new(model.Email, model.Password);
}