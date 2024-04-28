using Microsoft.AspNetCore.Components;
using NorthWind.Membership.Frontend.RazorViews.AuthenticationStateProviders;

namespace NorthWind.Membership.Frontend.RazorViews.Pages;

public partial class LogoutPage
{
    [Inject] private JwtAuthenticationStateProvider AuthenticationStateProvider { get; set; }
    [Inject] private NavigationManager NavigationManager { get; set; }

    private async ValueTask CloseSession()
    {
        await AuthenticationStateProvider.LogoutAsync();
        NavigationManager.NavigateTo("/");
    }
}