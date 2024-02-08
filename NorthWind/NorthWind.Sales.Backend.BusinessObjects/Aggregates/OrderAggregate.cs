namespace NorthWind.Sales.Backend.BusinessObjects.Aggregates;

public class OrderAggregate : Order
{
    readonly List<OrderDetail> OrderDetailsField = [];
    public IReadOnlyCollection<OrderDetail> OrderDetails => OrderDetailsField;

    private void AddDetail(int productId, decimal unitPrice, short quantity)
    {
        //Validaciones, Reglas de negocio, etc
        var existingOrderDetail = OrderDetailsField
            .FirstOrDefault(s => s.ProductId == productId);

        if (existingOrderDetail != default)
        {
            quantity += existingOrderDetail.Quantity;
            OrderDetailsField.Remove(existingOrderDetail);
        }

        OrderDetailsField.Add(new OrderDetail(productId, unitPrice, quantity));
    }

    public static OrderAggregate From(CreateOrderDto orderDto)
    {
        OrderAggregate orderAggregate = new()
        {
            CustomerId = orderDto.CustomerId,
            ShipAddress = orderDto.ShipAddress,
            ShipCity = orderDto.ShipCity,
            ShipCountry = orderDto.ShipCountry,
            ShipPostalCode = orderDto.ShipPostalCode
        };

        foreach (var item in orderDto.OrderDetails)
        {
            orderAggregate.AddDetail(item.ProductId, item.UnitPrice, item.Quantity);
        }

        return orderAggregate;
    }
}

