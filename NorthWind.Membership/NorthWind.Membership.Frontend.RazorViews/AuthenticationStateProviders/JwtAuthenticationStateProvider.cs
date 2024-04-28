using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.IdentityModel.JsonWebTokens;
using NorthWind.Membership.Entities.DTOs.UserLogin;
using NorthWind.Membership.Frontend.RazorViews.Interfaces;

namespace NorthWind.Membership.Frontend.RazorViews.AuthenticationStateProviders;

public class JwtAuthenticationStateProvider(ITokenStorage storage) : AuthenticationStateProvider
{
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        ClaimsIdentity identity = new();

        var tokens = await storage.GetTokensAsync();
        if (tokens is not null)
        {
            var handler = new JsonWebTokenHandler();
            var token = handler.ReadJsonWebToken(tokens.AccessToken);
            identity = new ClaimsIdentity(token.Claims, nameof(JwtAuthenticationStateProvider));
        }

        return new AuthenticationState(new ClaimsPrincipal(identity));
    }

    public async ValueTask LoginAsync(TokensDto tokens)
    {
        await storage.StoreTokenAsync(tokens);
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }

    public async ValueTask LogoutAsync()
    {
        await storage.RemoveTokensAsync();
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }
}