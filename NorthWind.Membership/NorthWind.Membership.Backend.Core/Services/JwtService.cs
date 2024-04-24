namespace NorthWind.Membership.Backend.Core.Services;

public class JwtService(IOptions<JwtOptions> options)
{
    SigningCredentials GetSigningCredentials()
    {
        var key = Encoding.UTF8.GetBytes(options.Value.SecurityKey);
        var secret = new SymmetricSecurityKey(key);
        return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
    }

    List<Claim> GetClaims(UserDto userDto)
        =>
        [
            new Claim(ClaimTypes.Name, userDto.Email),
            new Claim("FullName", $"{userDto.FirstName} {userDto.LastName}")
        ];

    SecurityTokenDescriptor GetTokenDescriptor(SigningCredentials signingCredentials, List<Claim> claims)
        => new()
        {
            Subject = new ClaimsIdentity(claims),
            Issuer = options.Value.ValidIssuer,
            Audience = options.Value.ValidAudience,
            Expires = DateTime.UtcNow.AddMinutes(options.Value.ExpireInMinutes),
            SigningCredentials = signingCredentials
        };

    public string GetToken(UserDto userData)
    {
        var credentials = GetSigningCredentials();
        var claims = GetClaims(userData);
        var tokenDescriptor = GetTokenDescriptor(credentials, claims);

        var tokenHandler = new JsonWebTokenHandler();
        return tokenHandler.CreateToken(tokenDescriptor);
    }
}