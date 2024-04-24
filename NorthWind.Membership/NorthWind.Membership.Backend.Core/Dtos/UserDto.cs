namespace NorthWind.Membership.Backend.Core.Dtos;

public class UserDto(string email, string firstName, string lastName)
{
    public string Email => email;
    public string FirstName => firstName;
    public string LastName => lastName;
}