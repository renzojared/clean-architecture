namespace NorthWind.Exceptions.Entities.Extensions;

internal static class HttpContextExtensions
{
    public static async ValueTask WriteProblemDetailsAsync(this HttpContext context, ProblemDetails details)
    {
        context.Response.ContentType = "application/problem+json";
        context.Response.StatusCode = details.Status.Value;
        var stream = context.Response.Body;
        await JsonSerializer.SerializeAsync(stream, details);
    }
}