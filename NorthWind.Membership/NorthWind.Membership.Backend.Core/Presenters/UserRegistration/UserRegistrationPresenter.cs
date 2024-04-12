using Microsoft.AspNetCore.Http;
using NorthWind.Membership.Backend.Core.Extensions;
using NorthWind.Membership.Backend.Core.Interfaces.UserRegistration;
using NorthWind.Membership.Backend.Core.Resources;
using NorthWind.Result.Entities;
using NorthWind.Validation.Entities.ValueObjects;

namespace NorthWind.Membership.Backend.Core.Presenters.UserRegistration;

public class UserRegistrationPresenter : IUserRegistrationOutputPort
{
    public IResult Result { get; private set; }

    public Task Handle(Result<IEnumerable<ValidationError>> userRegistrationResult)
    {
        userRegistrationResult.HandleError(
            errors =>
                Result = Results.Problem(errors.ToProblemDetails(
                    UserRegistrationMessages.UserRegistrationErrorTitle,
                    UserRegistrationMessages.UserRegistrationErrorDetail,
                    nameof(UserRegistrationPresenter))),
            () =>
                Result = Results.Ok()
        );

        return Task.CompletedTask;
    }
}