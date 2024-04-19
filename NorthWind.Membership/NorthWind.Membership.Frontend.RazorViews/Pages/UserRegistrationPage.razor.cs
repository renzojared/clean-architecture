using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using NorthWind.Membership.Frontend.RazorViews.ViewModels.UserRegistration;

namespace NorthWind.Membership.Frontend.RazorViews.Pages;

public partial class UserRegistrationPage : ComponentBase
{
    [Inject] private UserRegistrationViewModel ViewModel { get; set; }
    private ErrorBoundary ErrorBoundaryRef;

    void Recover()
    {
        ErrorBoundaryRef?.Recover();
    }
}