using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using NorthWind.Exceptions.Entities.Extensions;

namespace NorthWind.Exceptions.Entities.ExceptionHandlers;

internal class ExceptionHandlerOrchestrator : IExceptionHandler
{
    //Exception type and instance of handler
    private readonly Dictionary<Type, object> Handlers;

    public ExceptionHandlerOrchestrator(
        [FromKeyedServices(typeof(IExceptionHandler<>))]
        IEnumerable<object> handlers)
    {
        Handlers = [];
        foreach (var handler in handlers)
        {
            var exceptionType = handler.GetType()
                .GetInterfaces()
                .First(s => s.IsGenericType && s.GetGenericTypeDefinition() == typeof(IExceptionHandler<>))
                .GetGenericArguments()[0];

            Handlers.TryAdd(exceptionType, handler);
        }
    }
    
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception,
        CancellationToken cancellationToken)
    {
        var handled = false;

        if (Handlers.TryGetValue(exception.GetType(), out object handler))
        {
            var handlerType = handler.GetType();
            var details = (ProblemDetails)handlerType
                .GetMethod(nameof(IExceptionHandler<Exception>.Handle))
                .Invoke(handler, new object[] { exception });

            await httpContext.WriteProblemDetailsAsync(details);

            handled = true;
        }
        
        return handled;
    }
}