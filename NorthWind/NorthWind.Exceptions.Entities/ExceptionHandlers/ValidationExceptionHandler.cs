namespace NorthWind.Exceptions.Entities.ExceptionHandlers;

internal class ValidationExceptionHandler : IExceptionHandler<ValidationException>
{
    public ProblemDetails Handle(ValidationException exception)
    {
        var details = new ProblemDetails
        {
            Status = StatusCodes.Status400BadRequest,
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1",
            Title = ExceptionMessage.ValidationExceptionTitle,
            Detail = ExceptionMessage.ValidationExceptionDetail,
            Instance = $"{nameof(ProblemDetails)}/{nameof(ValidationException)}",
        };

        details.Extensions.Add("errors", exception.Errors);

        return details;
    }
}