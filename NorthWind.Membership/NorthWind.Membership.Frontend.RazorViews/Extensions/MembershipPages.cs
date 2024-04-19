using System.Reflection;

namespace NorthWind.Membership.Frontend.RazorViews.Extensions;

public static class MembershipPages
{
    public static Assembly Assembly => typeof(MembershipPages).Assembly;
}