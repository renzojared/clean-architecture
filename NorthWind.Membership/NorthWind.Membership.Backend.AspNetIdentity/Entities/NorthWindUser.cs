using Microsoft.AspNetCore.Identity;

namespace NorthWind.Membership.Backend.AspNetIdentity.Entities;

public class NorthWindUser : IdentityUser
{
    public string FirstName { get; set; }
    public string Lastname { get; set; }
}