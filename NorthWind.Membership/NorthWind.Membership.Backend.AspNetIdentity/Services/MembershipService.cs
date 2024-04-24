namespace NorthWind.Membership.Backend.AspNetIdentity.Services;

internal class MembershipService(UserManager<NorthWindUser> manager): IMembershipService
{
    public async Task<Result<IEnumerable<ValidationError>>> Register(UserRegistrationDto userData)
    {
        Result<IEnumerable<ValidationError>> result;

        var user = new NorthWindUser
        {
            UserName = userData.Email,
            Email = userData.Email,
            FirstName = userData.FirstName,
            Lastname = userData.LastName,
        };

        var createResult = await manager.CreateAsync(user, userData.Password);

        if (createResult.Succeeded)
            result = new Result<IEnumerable<ValidationError>>();
        else
            result = new Result<IEnumerable<ValidationError>>(createResult.Errors.ToValidationErrors());
        
        return result;
    }

    public async Task<UserDto> GetUserByCredentials(UserCredentialsDto userData)
    {
        UserDto foundUser = null;

        var user = await manager.FindByNameAsync(userData.Email);
        if (user != null && await manager.CheckPasswordAsync(user, userData.Password))
            foundUser = new UserDto(user.UserName, user.FirstName, user.Lastname);

        return foundUser;
    }
}