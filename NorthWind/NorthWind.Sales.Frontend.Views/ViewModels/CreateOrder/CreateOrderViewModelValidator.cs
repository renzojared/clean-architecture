namespace NorthWind.Sales.Frontend.Views.ViewModels.CreateOrder;

internal class CreateOrderViewModelValidator(IModelValidatorHub<CreateOrderDto> validator)
    : AbstractViewModelValidator<CreateOrderDto, CreateOrderViewModel>(validator,
        ValidationConstraint.AlwaysValidate)
{
}