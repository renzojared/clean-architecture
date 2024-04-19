namespace NorthWind.Membership.Backend.Core.Interfaces.UserRegistration;

internal interface IUserRegistrationOutputPort
{
    IResult Result { get; }
    Task Handle(Result<IEnumerable<ValidationError>> userRegistrationResult);
}