using Evento.Domain.SeedWork;

namespace Evento.Application.SeedWork;

public abstract class DomainNotificationBase<TEvent>
    : IDomainEventNotification<TEvent>
    where TEvent : IDomainEvent
{
    public Guid Id { get; }
    public TEvent DomainEvent { get; }

    public DomainNotificationBase(TEvent domainEvent)
        => (Id, DomainEvent) = (Guid.NewGuid(), domainEvent);
}
