namespace Evento.Infrastructure.Outbox;

public interface IOutboxMessageRepository
{
    Task<List<OutboxMessage>> GetUnprocessedMessagesAsync(int count = 20, CancellationToken ct = default);
    Task UpdateProcessOnAsync(IEnumerable<Guid> outboxIds, CancellationToken ct = default);
    Task InsertAsync(IEnumerable<OutboxMessage> messages, CancellationToken ct = default);
}
