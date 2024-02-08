namespace NorthWind.Sales.Backend.UseCases.CreateOrder;

internal class CreateOrderInteractor
    (ICreateOrderOutputPort outputPort, ICommandsRepository repository) : ICreateOrderInputPort
{
    public async Task Handle(CreateOrderDto orderDto)
    {
        //Validaciones aqui
        var order = OrderAggregate.From(orderDto);

        await repository.CreateOrder(order);
        await repository.SaveChanges();

        await outputPort.Handle(order);
    }
}

