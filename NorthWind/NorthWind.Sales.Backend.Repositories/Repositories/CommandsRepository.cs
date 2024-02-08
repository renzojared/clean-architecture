namespace NorthWind.Sales.Backend.Repositories.Repositories;

public class CommandsRepository(INorthWindSalesCommandsDataContext context) : ICommandsRepository
{
    public async Task CreateOrder(OrderAggregate order)
    {
        await context.AddOrderAsync(order);
        await context.AddOrderDetailAsync(
            order.OrderDetails
            .Select(s => new Entities.OrderDetail
            {
                Order = order,
                ProductId = s.ProductId,
                Quantity = s.Quantity,
                UnitPrice = s.UnitPrice
            }).ToArray());
    }

    public async Task SaveChanges()
        => await context.SaveChangesAsync();
}

