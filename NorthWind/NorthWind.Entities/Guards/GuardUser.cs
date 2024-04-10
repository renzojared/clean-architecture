using NorthWind.Entities.Interfaces;

namespace NorthWind.Entities.Guards;

public static class GuardUser
{
    public static void AgainstUnauthenticated(IUserService userService)
    {
        if (!userService.IsAuthenticated)
            throw new UnauthorizedAccessException();
    }
}