using Microsoft.AspNetCore.Http;
using NorthWind.Entities.Interfaces;

namespace NorthWind.UserServices;

internal class UserService(IHttpContextAccessor contextAccessor) : IUserService
{
    public bool IsAuthenticated
        => contextAccessor.HttpContext.User.Identity.IsAuthenticated;

    public string UserName
        => contextAccessor.HttpContext.User.Identity.Name;

    public string FullName
        => contextAccessor.HttpContext.User.Claims
            .Where(s => s.Type == "FullName")
            .Select(s => s.Value)
            .FirstOrDefault();
}