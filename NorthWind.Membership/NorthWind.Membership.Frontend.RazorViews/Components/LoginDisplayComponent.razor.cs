using Microsoft.AspNetCore.Components.Authorization;

namespace NorthWind.Membership.Frontend.RazorViews.Components;

public partial class LoginDisplayComponent
{
    private string GetUserName(AuthenticationState context)
        => context.User.Claims
            .Where(s => s.Type == "FullName")
            .Select(s => s.Value)
            .FirstOrDefault() ?? context.User.Identity.Name;
}