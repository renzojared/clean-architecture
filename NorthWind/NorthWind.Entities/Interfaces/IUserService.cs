namespace NorthWind.Entities.Interfaces;

public interface IUserService
{
    bool IsAuthenticated { get; }
    string UserName { get; }
    string FullName { get; }
}