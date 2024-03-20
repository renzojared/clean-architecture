namespace NorthWind.Exceptions.Entities.ExceptionHandlers;

internal class UpdateExceptionHandler(ILogger<UpdateExceptionHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception,
        CancellationToken cancellationToken)
    {
        var handled = false;

        if (exception is UpdateException ex)
        {
            var details = new ProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError,
                Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1",
                Title = ExceptionMessage.UpdateExceptionTitle,
                Detail = ExceptionMessage.UpdateExceptionDetail,
                Instance = $"{nameof(ProblemDetails)}/{nameof(UpdateException)}",
            };

            logger.LogError(
                exception,
                ExceptionMessage.UpdateExceptionTitle + ":" + string.Join(" ", ex.Entities));

            await httpContext.WriteProblemDetailsAsync(details);

            handled = true;
        }

        return handled;
    }
}