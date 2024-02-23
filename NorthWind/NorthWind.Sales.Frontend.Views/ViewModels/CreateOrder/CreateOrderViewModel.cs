namespace NorthWind.Sales.Frontend.Views.ViewModels.CreateOrder;

public class CreateOrderViewModel(ICreateOrderGateway gateway)
{
    public string CustomerId { get; set; }
    public string ShipAddress { get; set; }
    public string ShipCity { get; set; }
    public string ShipCountry { get; set; }
    public string ShipPostalCode { get; set; }
    public List<CreateOrderDetailViewModel> OrderDetails { get; set; } = [];

    public string InformationMessage { get; private set; }

    public void AddNewOrderDetailItem()
        => OrderDetails.Add(new CreateOrderDetailViewModel());

    public async Task Send()
    {
        InformationMessage = "";

        var orderId = await gateway.CreateOrderAsyc((CreateOrderDto)this);
        
        InformationMessage = string.Format(CreateOrderMessages.CreateOrderTemplate, orderId);
    }

    public static explicit operator CreateOrderDto(CreateOrderViewModel model)
        => new CreateOrderDto(
            model.CustomerId,
            model.ShipAddress,
            model.ShipCity,
            model.ShipCountry,
            model.ShipPostalCode,
            model.OrderDetails.Select(s => new CreateOrderDetailDto(
                s.ProductId,
                s.UnitPrice,
                s.Quantity)));
}