namespace NorthWind.Sales.Validators.Entities.CreateOrder;

internal class CreateOrderDetailDtoValidator : AbstractModelValidator<CreateOrderDetailDto>
{
    public CreateOrderDetailDtoValidator(IValidationService<CreateOrderDetailDto> validator) : base(validator)
    {
        AddRuleFor(s => s.ProductId)
            .GreaterThan(0, CreateOrderMessages.ProductIdGreaterThanZero);

        AddRuleFor<int>(s => s.Quantity)
            .GreaterThan(0, CreateOrderMessages.QuantityGreaterThanZero);

        AddRuleFor(s => s.UnitPrice)
            .GreaterThan<decimal>(0, CreateOrderMessages.UnitPriceGreaterThanZero);
    }
}