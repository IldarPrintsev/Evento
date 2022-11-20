using Evento.Domain.SeedWork;
using Evento.Infrastructure.DomainEvents.Handler;
using Evento.Infrastructure.Outbox;

namespace Evento.Infrastructure.Persistence.EF;

public sealed class EFUnitOfWork : IUnitOfWork
{
    private readonly EventoContext _context;
    private readonly IDomainEventHandler _domainEventHandler;

    public IOutboxMessageRepository OutboxMessageRepository { get; }

    public EFUnitOfWork(
        EventoContext context,
        IDomainEventHandler domainEventHandler,
        IOutboxMessageRepository outboxMessageRepository)
    {
        _context = context;
        _domainEventHandler = domainEventHandler;
        OutboxMessageRepository = outboxMessageRepository;
    }

    public async Task<int> CommitAsync<TEntity>(TEntity entity, CancellationToken ct = default) 
        where TEntity : IEntity
    {
        await _domainEventHandler.HandleDomainEventsAsync(entity, OutboxMessageRepository, ct);

        return await _context.SaveChangesAsync(ct);
    }

    public void Dispose() 
        => _context.Dispose();
}
