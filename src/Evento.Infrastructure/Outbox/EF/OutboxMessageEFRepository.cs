using Evento.Infrastructure.Persistence.EF;
using Microsoft.EntityFrameworkCore;

namespace Evento.Infrastructure.Outbox.EF;

public class OutboxMessageEfRepository : IOutboxMessageRepository
{
    private readonly EventoContext _context;

    public OutboxMessageEfRepository(EventoContext context)
        => _context = context;

    public async Task<List<OutboxMessage>> GetUnprocessedMessagesAsync(int count, CancellationToken ct) 
        => await _context.OutboxMessages.Where(x => !x.ProcessedOn.HasValue)
                                        .Take(count)
                                        .ToListAsync(ct);

    public async Task InsertAsync(IEnumerable<OutboxMessage> messages, CancellationToken ct) 
        => await _context.OutboxMessages.AddRangeAsync(messages, ct);

    public async Task UpdateProcessOnAsync(IEnumerable<Guid> outboxIds, CancellationToken ct)
    {
        var entities = await _context.Set<OutboxMessage>()
                                     .AsTracking()
                                     .Where(x => outboxIds.Contains(x.Id))
                                     .ToListAsync(ct);

        entities?.ForEach(x => x.ProcessedOn = DateTime.UtcNow);
    }
}
