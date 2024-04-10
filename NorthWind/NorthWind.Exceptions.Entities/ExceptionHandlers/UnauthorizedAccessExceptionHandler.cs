namespace NorthWind.Exceptions.Entities.ExceptionHandlers;

internal class UnauthorizedAccessExceptionHandler(ILogger<UnauthorizedAccessExceptionHandler> logger)
    : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception,
        CancellationToken cancellationToken)
    {
        var handled = false;

        if (exception is UnauthorizedAccessException)
        {
            var details = new ProblemDetails
            {
                Status = StatusCodes.Status401Unauthorized,
                Type = "https://datatracker.ietf.org/doc/html/rfc7235#section-3.1",
                Title = ExceptionMessage.UnauthorizedAccessExceptionTitle,
                Detail = ExceptionMessage.UnauthorizedAccessExceptionDetail,
                Instance = $"{nameof(ProblemDetails)}/{exception.GetType().Name}"
            };

            logger.LogError(exception, ExceptionMessage.UnauthorizedAccessExceptionTitle);

            await httpContext.WriteProblemDetailsAsync(details);

            handled = true;
        }

        return handled;
    }
}