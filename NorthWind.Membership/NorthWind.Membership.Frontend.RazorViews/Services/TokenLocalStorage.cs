using System.Text.Json;
using Microsoft.JSInterop;
using NorthWind.Membership.Entities.DTOs.UserLogin;
using NorthWind.Membership.Frontend.RazorViews.Interfaces;

namespace NorthWind.Membership.Frontend.RazorViews.Services;

internal class TokenLocalStorage(IJSRuntime jsRuntime) : ITokenStorage
{
    private const string StorageKey = "tokens";
    private const string StoreIdentifier = "localStorage.setItem";
    private const string GetIdentifier = "localStorage.getItem";
    private const string RemoveIdentifier = "localStorage.removeItem";
         
    public async Task<TokensDto> GetTokensAsync()
    {
        var value = await jsRuntime.InvokeAsync<string>(GetIdentifier, StorageKey);
        return value is null ? null : JsonSerializer.Deserialize<TokensDto>(value);
    }

    public async Task StoreTokenAsync(TokensDto tokens)
    {
        var value = JsonSerializer.Serialize(tokens);
        await jsRuntime.InvokeVoidAsync(StoreIdentifier, StorageKey, value);
    }

    public async Task RemoveTokensAsync()
    {
        await jsRuntime.InvokeVoidAsync(RemoveIdentifier, StorageKey);
    }
}