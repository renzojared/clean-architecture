namespace NorthWind.Sales.Backend.UseCases.CreateOrder;

public class CreateOrderProductValidator(IQueriesRepository repository) : IModelValidator<CreateOrderDto>
{
    private readonly List<ValidationError> ErrorsField = [];
    public ValidationConstraint Constraint => ValidationConstraint.ValidateIfThereAreNoPreviousErrors;
    public IEnumerable<ValidationError> Errors => ErrorsField;
    public async Task<bool> Validate(CreateOrderDto model)
    {
        var requiredQuantities = model.OrderDetails
            .GroupBy(s => s.ProductId)
            .Select(s => new ProductUnitsInStock(
                s.Key, (short)s.Sum(s => s.Quantity)));

        var productsIds = requiredQuantities.Select(s => s.ProductId);

        var inStockQuantities = await repository.GetProductsUnitsInStock(productsIds);

        foreach (var item in requiredQuantities)
        {
            var productFound = inStockQuantities
                .FirstOrDefault(s => s.ProductId == item.ProductId);

            if (productFound is null)
            {
                var propertyName =
                    GetPropertyNameWithIndex(model, item.ProductId, nameof(CreateOrderDetailDto.ProductId));

                ErrorsField.Add(new ValidationError(
                    propertyName,
                    string.Format(CreateOrderMessages.ProductIdNotFoundErrorTemplate, item.ProductId)));
            }
            else if (item.UnitsInStock > productFound.UnitsInStock)
            {
                var propertyName =
                    GetPropertyNameWithIndex(model, item.ProductId, nameof(CreateOrderDetailDto.Quantity));

                ErrorsField.Add(new ValidationError(
                    propertyName,
                    string.Format(CreateOrderMessages.UnitsInStockLessThanQuantityErrorTemplate,
                        productFound.UnitsInStock, item.UnitsInStock, item.ProductId)));
            }
        }

        return !ErrorsField.Any();
    }

    private static string GetPropertyNameWithIndex(CreateOrderDto model, int productId, string propertyName)
    {
        var orderDetail = model.OrderDetails
            .FirstOrDefault(s => s.ProductId == productId);

        var orderDetailIndex = model.OrderDetails.ToList().IndexOf(orderDetail);

        return $"{nameof(model.OrderDetails)}[{orderDetailIndex}].{propertyName}";
    }
}