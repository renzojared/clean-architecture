using NorthWind.RazorComponents.Validators;
using NorthWind.Validation.Entities.ValueObjects;

namespace NorthWind.Sales.Frontend.Views.ViewModels.CreateOrder;

public class CreateOrderViewModel(ICreateOrderGateway gateway, IModelValidatorHub<CreateOrderViewModel> validator)
{
    public ModelValidator<CreateOrderViewModel> ModelValidatorComponentReference { get; set; }
    public IModelValidatorHub<CreateOrderViewModel> Validator => validator;
    public string CustomerId { get; set; }
    public string ShipAddress { get; set; }
    public string ShipCity { get; set; }
    public string ShipCountry { get; set; }
    public string ShipPostalCode { get; set; }
    public ICollection<CreateOrderDetailViewModel> OrderDetails { get; set; } = [];

    public string InformationMessage { get; private set; }

    public void AddNewOrderDetailItem()
        => OrderDetails.Add(new CreateOrderDetailViewModel());

    public async Task Send()
    {
        InformationMessage = "";
        try
        {
            var orderId = await gateway.CreateOrderAsync((CreateOrderDto)this);
            InformationMessage = string.Format(CreateOrderMessages.CreateOrderTemplate, orderId);
        }
        catch (HttpRequestException ex)
        {
            if (ex.Data.Contains("Errors"))
            {
                var errors = ex.Data["Errors"] as IEnumerable<ValidationError>;
                ModelValidatorComponentReference.AddErrors(errors);
            }
            else
                throw;
        }
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