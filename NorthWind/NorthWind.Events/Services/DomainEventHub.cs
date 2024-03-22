using NorthWind.Events.Interfaces;

namespace NorthWind.Events.Services;

internal class DomainEventHub<EventType>(IEnumerable<IDomainEventHandler<EventType>> eventHandlers)
    : IDomainEventHub<EventType> where EventType : IDomainEvent
{
    public async Task Raise(EventType eventTypeInstance)
    {
        foreach (var handler in eventHandlers)
        {
            await handler.Handle(eventTypeInstance);
        }
    }
}