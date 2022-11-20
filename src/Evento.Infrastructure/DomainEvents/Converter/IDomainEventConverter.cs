using Evento.Domain.SeedWork;
using Evento.Infrastructure.Outbox;

namespace Evento.Infrastructure.DomainEvents.Converter;

public interface IDomainEventConverter
{
    OutboxMessage ConvertToOutboxMessage(IDomainEvent domainEvent);
    IDomainEvent? ConvertFromOutboxMessage(OutboxMessage outboxMessage);
}
