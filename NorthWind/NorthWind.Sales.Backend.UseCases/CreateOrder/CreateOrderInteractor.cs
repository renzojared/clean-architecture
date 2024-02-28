namespace NorthWind.Sales.Backend.UseCases.CreateOrder;

internal class CreateOrderInteractor(
    ICreateOrderOutputPort outputPort,
    ICommandsRepository repository,
    IModelValidatorHub<CreateOrderDto> modelValidatorHub) : ICreateOrderInputPort
{
    public async Task Handle(CreateOrderDto orderDto)
    {
        await GuardModel.AgainstNotValid(modelValidatorHub, orderDto);

        var order = OrderAggregate.From(orderDto);

        await repository.CreateOrder(order);
        await repository.SaveChanges();

        await outputPort.Handle(order);
    }
}

