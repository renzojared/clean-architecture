namespace NorthWind.Exceptions.Entities.ExceptionHandlers;

internal class UpdateExceptionHandler(ILogger<UpdateExceptionHandler> logger) : IExceptionHandler<UpdateException>
{
    public ProblemDetails Handle(UpdateException exception)
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
            ExceptionMessage.UpdateExceptionTitle + ":" + string.Join(" ", exception.Entities));

        return details;
    }
}