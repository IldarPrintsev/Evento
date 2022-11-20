using System.Text.Json;
using Evento.Domain.SeedWork;
using Evento.Infrastructure.Outbox;

namespace Evento.Infrastructure.DomainEvents.Converter;

public sealed class DomainEventJsonConverter : IDomainEventConverter
{
    public OutboxMessage ConvertToOutboxMessage(IDomainEvent domainEvent)
    {
        string type = domainEvent.GetType().Name;
        string data = JsonSerializer.Serialize(domainEvent);
        var outboxMessage = new OutboxMessage(
            domainEvent.OccurredOn,
            type,
            data);

        return outboxMessage;
    }

    public IDomainEvent? ConvertFromOutboxMessage(OutboxMessage outboxMessage)
    {
        var domainEvent = JsonSerializer.Deserialize<IDomainEvent>(outboxMessage.Data);

        return domainEvent;
    }
}
