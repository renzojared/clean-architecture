namespace NorthWind.Membership.Entities.DTOs.UserLogin;

public class TokensDto(string accessToken)
{
    public string AccessToken => accessToken;
};