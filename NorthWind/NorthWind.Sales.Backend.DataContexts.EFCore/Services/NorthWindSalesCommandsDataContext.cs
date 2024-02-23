using NorthWind.Sales.Backend.DataContexts.EFCore.DataContexts;

namespace NorthWind.Sales.Backend.DataContexts.EFCore.Services;

internal class NorthWindSalesCommandsDataContext(IOptions<DBOptions> dbOptions)
    : NorthWindSalesContext(dbOptions), INorthWindSalesCommandsDataContext
{
    public async Task AddOrderAsync(Order order)
        => await AddAsync(order);

    public async Task AddOrderDetailAsync(IEnumerable<OrderDetail> orderDetails)
        => await AddRangeAsync(orderDetails);

    public async Task SaveChangesAsync()
        => await base.SaveChangesAsync();
}