namespace Evento.Infrastructure.Outbox.EF;

public class OutboxMessageEfRepository : IOutboxMessageRepository
{
    Task<List<OutboxMessage>> IOutboxMessageRepository.GetManyAsync(int count, CancellationToken ct) 
        => throw new NotImplementedException();
    Task IOutboxMessageRepository.ProcessAsync(IEnumerable<Guid> outboxIds, CancellationToken ct) 
        => throw new NotImplementedException();
}
