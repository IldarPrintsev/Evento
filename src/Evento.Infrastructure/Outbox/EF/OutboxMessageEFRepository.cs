namespace Evento.Infrastructure.Outbox.EF;

public class OutboxMessageEfRepository : IOutboxMessageRepository
{
    Task<List<OutboxMessage>> IOutboxMessageRepository.GetUnprocessedMessagesAsync(int count, CancellationToken ct) => throw new NotImplementedException();
    Task IOutboxMessageRepository.InsertAsync(IEnumerable<OutboxMessage> messages, CancellationToken ct) => throw new NotImplementedException();
    Task IOutboxMessageRepository.ProcessAsync(IEnumerable<Guid> outboxIds, CancellationToken ct) 
        => throw new NotImplementedException();
}
