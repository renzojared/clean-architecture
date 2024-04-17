namespace NorthWind.Membership.Backend.AspNetIdentity.Options;

public class MembershipDbOptions
{
    public const string SectionKey = nameof(MembershipDbOptions);
    public string ConnectionString { get; set; }
}