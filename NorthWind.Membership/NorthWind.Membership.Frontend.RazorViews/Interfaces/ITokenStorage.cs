using NorthWind.Membership.Entities.DTOs.UserLogin;

namespace NorthWind.Membership.Frontend.RazorViews.Interfaces;

public interface ITokenStorage
{
    Task<TokensDto> GetTokensAsync();
    Task StoreTokenAsync(TokensDto tokens);
    Task RemoveTokensAsync();
}