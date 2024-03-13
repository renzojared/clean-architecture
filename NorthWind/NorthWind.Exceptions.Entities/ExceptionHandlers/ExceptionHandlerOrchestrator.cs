using Microsoft.AspNetCore.Diagnostics;

namespace NorthWind.Exceptions.Entities.ExceptionHandlers;

internal class ExceptionHandlerOrchestrator : IExceptionHandler
{
    public ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception,
        CancellationToken cancellationToken)
    {
        //TODO: implement orchestrator
        throw new NotImplementedException();
    }
}