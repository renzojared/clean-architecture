using Microsoft.AspNetCore.Components;
using NorthWind.Membership.Frontend.RazorViews.ViewModels.UserLogin;

namespace NorthWind.Membership.Frontend.RazorViews.Components;

public partial class UserLoginComponent
{
    [Parameter]
    public UserLoginViewModel ViewModel { get; set; }
}