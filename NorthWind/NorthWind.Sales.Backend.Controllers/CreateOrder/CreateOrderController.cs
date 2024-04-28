using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NorthWind.Exceptions.Entities.Exceptions;
using NorthWind.Sales.Backend.BusinessObjects.Interfaces.CreateOrder;
using NorthWind.Sales.Entities.Dtos.CreateOrder;
using NorthWind.Sales.Entities.ValueObjects;

namespace Microsoft.AspNetCore.Builder;

public static class CreateOrderController
{
    public static WebApplication UseCreateOrderController(this WebApplication app)
    {
        app.MapPost(Endpoints.CreateOrder, CreateOrder)
            .ProducesValidationProblem()
            .ProducesProblem(StatusCodes.Status500InternalServerError) //Review
            .RequireAuthorization();

        return app;
    }
    public static async Task<int> CreateOrder(CreateOrderDto orderDto,
        ICreateOrderInputPort inputPort,
        ICreateOrderOutputPort presenter)
    {
        await inputPort.Handle(orderDto);

        return presenter.OrderId;
    }
}