namespace NorthWind.Membership.Entities.ValueObjects;

public class Endpoints
{
    public const string Register = $"/user/{nameof(Register)}";
    public const string Login = $"/user/{nameof(Login)}";
}