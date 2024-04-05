namespace NorthWind.Sales.Backend.UseCases.CreateOrder;

public class SendEmailWhenSpecialOrderCreatedEventHandler(IMailService mailService)
    : IDomainEventHandler<SpecialOrderCreatedEvent>
{
    public async Task Handle(SpecialOrderCreatedEvent createdOrder)
        => await mailService.SendMailToAdministrator(
            CreateOrderMessages.SendEmailSubject,
            string.Format(CreateOrderMessages.SendEmailBodyTemplate, createdOrder.OrderId, createdOrder.ProductsCount));
}