namespace NorthWind.Events.Interfaces;

public interface IDomainEventHandler<EventType> where EventType : IDomainEvent
{
    Task Handle(EventType eventTypeInstance);
}