using Evento.Domain.SeedWork;
using MediatR;

namespace Evento.Application.DomainEvents;

public class DomainEventNotification<TDomainEvent> : INotification
    where TDomainEvent : IDomainEvent
{
    public TDomainEvent DomainEvent { get; }

    public DomainEventNotification(TDomainEvent domainEvent)
        => DomainEvent = domainEvent;
}
