using NorthWind.Sales.Backend.BusinessObjects.ValueObjects;

namespace NorthWind.Sales.Backend.Repositories.Repositories;

internal class QueriesRepository(INorthWindSalesQueriesDataContext context) : IQueriesRepository
{
    public async Task<IEnumerable<ProductUnitsInStock>> GetProductsUnitsInStock(IEnumerable<int> productId)
    {
        var queryable = context.Products
            .Where(s => productId.Contains(s.Id))
            .Select(s => new ProductUnitsInStock(s.Id, s.UnitsInStock));

        return await context.ToListAsync(queryable);
    }

    public async Task<decimal?> GetCustomerCurrentBalance(string customerId)
    {
        var queryable = context.Customers
            .Where(s => s.Id == customerId)
            .Select(s => new { s.CurrentBalance });

        var result = await context.FirstOrDefaultAsync(queryable);
        
        return result?.CurrentBalance;
    }
}