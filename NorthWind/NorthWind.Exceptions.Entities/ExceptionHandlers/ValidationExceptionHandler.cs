namespace NorthWind.Exceptions.Entities.ExceptionHandlers;

internal class ValidationExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception,
        CancellationToken cancellationToken)
    {
        var handled = false;

        if (exception is ValidationException ex)
        {
            var details = new ProblemDetails
            {
                Status = StatusCodes.Status400BadRequest,
                Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1",
                Title = ExceptionMessage.ValidationExceptionTitle,
                Detail = ExceptionMessage.ValidationExceptionDetail,
                Instance = $"{nameof(ProblemDetails)}/{nameof(ValidationException)}",
            };

            details.Extensions.Add("errors", ex.Errors);

            await httpContext.WriteProblemDetailsAsync(details);

            handled = true;
        }

        return handled;
    }
}