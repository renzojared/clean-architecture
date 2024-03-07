namespace NorthWind.Sales.Backend.UseCases.CreateOrder;

internal class CreateOrderCustomerValidator(IQueriesRepository repository) : IModelValidator<CreateOrderDto>
{
    private readonly List<ValidationError> ErrorsField = [];
    public ValidationConstraint Constraint => ValidationConstraint.ValidateIfThereAreNoPreviousErrors;
    public IEnumerable<ValidationError> Errors => ErrorsField;
    public async Task<bool> Validate(CreateOrderDto model)
    {
        var currentBalance = await repository.GetCustomerCurrentBalance(model.CustomerId);

        if (currentBalance is null)
            ErrorsField.Add(new ValidationError(
                nameof(model.CustomerId),
                CreateOrderMessages.CustomerIdNotFoundError));
        else if (currentBalance > 0)
            ErrorsField.Add(new ValidationError(
                nameof(model.CustomerId),
                string.Format(CreateOrderMessages.CustomerWithBalanceErrorTemplate, model.CustomerId, currentBalance)));

        return !ErrorsField.Any();
    }
}