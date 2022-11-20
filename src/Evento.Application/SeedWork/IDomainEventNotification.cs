using MediatR;

namespace Evento.Application.SeedWork;

public interface IDomainEventNotification<out TEvent> 
    : INotification
{
    Guid Id { get; }
    TEvent DomainEvent { get; }
}
