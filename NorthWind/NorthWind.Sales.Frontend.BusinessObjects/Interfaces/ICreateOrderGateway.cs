using NorthWind.Sales.Entities.Dtos.CreateOrder;

namespace NorthWind.Sales.Frontend.BusinessObjects.Interfaces;

public interface ICreateOrderGateway
{
    Task<int> CreateOrderAsync(CreateOrderDto orderDto);
}