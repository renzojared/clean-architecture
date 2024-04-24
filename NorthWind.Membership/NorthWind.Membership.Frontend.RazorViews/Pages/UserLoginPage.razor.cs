using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using NorthWind.Membership.Frontend.RazorViews.ViewModels.UserLogin;

namespace NorthWind.Membership.Frontend.RazorViews.Pages;

public partial class UserLoginPage
{
    private const string RouteTemplate = "/user/login";
    [Inject] private UserLoginViewModel ViewModel { get; set; }
    [Inject] private NavigationManager NavigationManager { get; set; }
    private ErrorBoundary ErrorBoundaryRef;

    void Recover() => ErrorBoundaryRef?.Recover();

    protected override void OnInitialized()
    {
        ViewModel.OnLogin += OnLogin;
    }

    void OnLogin()
    {
        if (NavigationManager.Uri.EndsWith(RouteTemplate))
        {
            NavigationManager.NavigateTo("");
        }
        else
        {
            NavigationManager.NavigateTo(NavigationManager.Uri);
        }
    }
}