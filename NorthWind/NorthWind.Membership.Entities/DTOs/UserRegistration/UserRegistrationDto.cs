namespace NorthWind.Membership.Entities.DTOs.UserRegistration;

public class UserRegistrationDto(string email, string password, string firstName, string lastName)
{
    public string Email => email;
    public string Password => password;
    public string FirstName => firstName;
    public string LastName => lastName;
}