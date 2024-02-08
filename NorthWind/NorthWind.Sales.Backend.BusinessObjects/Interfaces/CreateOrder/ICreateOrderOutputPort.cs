namespace NorthWind.Sales.Backend.BusinessObjects.Interfaces.CreateOrder;

public interface ICreateOrderOutputPort
{
    int OrderId { get; }
    Task Handle(OrderAggregate addedOrder);
}

