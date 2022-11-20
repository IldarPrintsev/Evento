using Evento.Domain.SeedWork;
using Evento.Infrastructure.Outbox;

namespace Evento.Infrastructure.DomainEvents.Handler;

public interface IDomainEventHandler
{
    Task HandleDomainEventsAsync(IEntity entity, IOutboxMessageRepository outboxMessageRepository, CancellationToken ct = default);
    Task<List<IDomainEvent>> FetchDomainEventsAsync(IOutboxMessageRepository outboxMessageRepository, int eventsAmount = 20, CancellationToken ct = default);
}
