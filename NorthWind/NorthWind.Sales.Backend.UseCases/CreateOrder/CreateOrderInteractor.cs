using NorthWind.DomainLogs.Entities.Interfaces;
using NorthWind.DomainLogs.Entities.ValueObjects;
using NorthWind.Sales.Backend.BusinessObjects.Specifications;

namespace NorthWind.Sales.Backend.UseCases.CreateOrder;

internal class CreateOrderInteractor(
    ICreateOrderOutputPort outputPort,
    ICommandsRepository repository,
    IModelValidatorHub<CreateOrderDto> modelValidatorHub,
    IDomainEventHub<SpecialOrderCreatedEvent> domainEventHub,
    IDomainLogger domainLogger,
    IUserService userService) : ICreateOrderInputPort
{
    public async Task Handle(CreateOrderDto orderDto)
    {
        if (!userService.IsAuthenticated)
            throw new UnauthorizedAccessException();

        await GuardModel.AgainstNotValid(modelValidatorHub, orderDto);
        await domainLogger.LogInformation(new DomainLog(CreateOrderMessages.StartingPurchaseOrderCreation,
            userService.UserName));
        var order = OrderAggregate.From(orderDto);

        await repository.CreateOrder(order);
        await repository.SaveChanges();

        await domainLogger.LogInformation(new DomainLog(
            string.Format(CreateOrderMessages.PurchaseOrderCreatedTemplate, order.Id), userService.UserName));

        await outputPort.Handle(order);

        if (new SpecialOrderSpecification().IsSatisfiedBy(order))
            await domainEventHub.Raise(new SpecialOrderCreatedEvent(order.Id, order.OrderDetails.Count));
    }

    private Task WindowsHandle(CreateOrderDto orderDto)
    {
        /*
        await GuardModel.AgainstNotValid(modelValidatorHub, orderDto);
        await domainLogger.LogInformation(new DomainLog(CreateOrderMessages.StartingPurchaseOrderCreation));
        var order = OrderAggregate.From(orderDto);

        try
        {
            domainTransaction.BeginTransaction();

            await repository.CreateOrder(order);
            await repository.SaveChanges();

            await domainLogger.LogInformation(new DomainLog(
                string.Format(CreateOrderMessages.PurchaseOrderCreatedTemplate, order.Id)));

            await outputPort.Handle(order);

            if (order.OrderDetails.Count > 3)
                await domainEventHub.Raise(new SpecialOrderCreatedEvent(order.Id, order.OrderDetails.Count));

            domainTransaction.CommitTransaction();
        }
        catch
        {
            domainTransaction.RollbackTransaction();
            await domainLogger.LogInformation(new DomainLog(
                string.Format(CreateOrderMessages.OrderCreationCancelledTemplate, order.Id)));
            throw;
        }*/
        return Task.CompletedTask;
    }
}