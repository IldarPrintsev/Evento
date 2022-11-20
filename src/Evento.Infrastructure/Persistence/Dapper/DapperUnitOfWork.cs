using System.Data;
using Evento.Domain.SeedWork;
using Evento.Infrastructure.DomainEvents.Handler;
using Evento.Infrastructure.Outbox;

namespace Evento.Infrastructure.Persistence.EF;

public sealed class DapperUnitOfWork : IUnitOfWork
{
    private readonly IDbTransaction _dbTransaction;
    private readonly IDomainEventHandler _domainEventHandler;

    public IOutboxMessageRepository OutboxMessageRepository { get; }

    public DapperUnitOfWork(
        IDbTransaction dbTransaction,
        IDomainEventHandler domainEventHandler,
        IOutboxMessageRepository outboxMessageRepository)
    {
        _dbTransaction = dbTransaction;
        _domainEventHandler = domainEventHandler;
        OutboxMessageRepository = outboxMessageRepository;
    }

    public async Task<int> CommitAsync<TEntity>(TEntity entity, CancellationToken ct = default) 
        where TEntity : IEntity
    {
        try
        {
            await _domainEventHandler.HandleDomainEventsAsync(entity, OutboxMessageRepository, ct);

            _dbTransaction.Commit();
            _dbTransaction.Connection?.BeginTransaction();

            return 1;
        }
        catch
        {
            _dbTransaction.Rollback();
            throw;
        }
    }

    public void Dispose()
    {
        _dbTransaction.Connection?.Close();
        _dbTransaction.Connection?.Dispose();
        _dbTransaction.Dispose();
    }
}
