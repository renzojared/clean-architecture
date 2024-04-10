using NorthWind.Entities.Interfaces;

namespace NorthWind.UserServices;

public class UserServiceFake : IUserService
{
    public bool IsAuthenticated => true;
    public string UserName => "user@northwind.com";
    public string FullName => "Test user";
}