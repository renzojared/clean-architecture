using NorthWind.Entities.Interfaces;

namespace NorthWind.UserServices;

public class UserService : IUserService
{
    public bool IsAuthenticated { get; }
    public string UserName { get; }
    public string FullName { get; }
}