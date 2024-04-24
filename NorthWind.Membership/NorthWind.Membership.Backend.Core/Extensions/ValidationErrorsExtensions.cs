namespace NorthWind.Membership.Backend.Core.Extensions;

internal static class ValidationErrorsExtensions
{
    public static ProblemDetails ToProblemDetails(this IEnumerable<ValidationError> errors, string title, string detail,
        string instance)
    {
        ProblemDetails details = new()
        {
            Status = StatusCodes.Status400BadRequest,
            Type = "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1",
            Title = title,
            Detail = detail,
            Instance = $"{nameof(ProblemDetails)}/{instance}"
        };
        details.Extensions.Add("errors", errors);

        return details;
    }
}