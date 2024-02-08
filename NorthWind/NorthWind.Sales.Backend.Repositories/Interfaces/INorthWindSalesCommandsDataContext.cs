namespace NorthWind.Sales.Backend.Repositories.Interfaces;

public interface INorthWindSalesCommandsDataContext
{
    Task AddOrderAsync(Order order);
    Task AddOrderDetailAsync(IEnumerable<Entities.OrderDetail> orderDetails);
    Task SaveChangesAsync();
}

