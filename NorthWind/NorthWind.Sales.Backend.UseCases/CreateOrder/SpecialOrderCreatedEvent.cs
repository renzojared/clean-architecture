namespace NorthWind.Sales.Backend.UseCases.CreateOrder;

public class SpecialOrderCreatedEvent(int orderId, int productsCount) : IDomainEvent
{
    public int OrderId => orderId;
    public int ProductsCount => productsCount;
}