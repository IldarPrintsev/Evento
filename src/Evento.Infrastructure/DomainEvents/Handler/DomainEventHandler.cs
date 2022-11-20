using System.Text.Json;
using Evento.Domain.SeedWork;
using Evento.Infrastructure.DomainEvents.Converter;
using Evento.Infrastructure.Outbox;

namespace Evento.Infrastructure.DomainEvents.Handler;

public sealed class DomainEventHandler : IDomainEventHandler
{
    private readonly IDomainEventConverter _domainEventConverter;

    public DomainEventHandler(IDomainEventConverter domainEventConverter)
        => _domainEventConverter = domainEventConverter;

    public async Task HandleDomainEventsAsync(
        IEntity entity,
        IOutboxMessageRepository outboxMessageRepository,
        CancellationToken ct = default)
    {
        if (!entity.DomainEvents.Any())
        {
            return;
        }

        var outboxMessages = entity.DomainEvents.Select(_domainEventConverter.ConvertToOutboxMessage);
        await outboxMessageRepository.InsertAsync(outboxMessages, ct);

        entity.ClearDomainEvents();
    }

    public async Task<List<IDomainEvent>> FetchDomainEventsAsync(
        IOutboxMessageRepository outboxMessageRepository,
        int eventsAmount = 20,
        CancellationToken ct = default)
    {
        var result = new List<IDomainEvent>();
        var messages = await outboxMessageRepository.GetUnprocessedMessagesAsync(eventsAmount, ct);
        if (messages is null || !messages.Any())
        {
            return result;
        }

        foreach (var message in messages)
        {
            var domainEvent = _domainEventConverter.ConvertFromOutboxMessage(message);
            if (domainEvent is null)
            {
                continue;
            }

            result.Add(domainEvent);
        }

        return result;
    }
}
