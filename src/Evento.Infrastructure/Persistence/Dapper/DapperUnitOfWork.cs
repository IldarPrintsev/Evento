using System.Data;
using Evento.Domain.Parties;
using Evento.Domain.SeedWork;
using Evento.Domain.Users;
using Evento.Infrastructure.DomainEvents.Handler;
using Evento.Infrastructure.Outbox;

namespace Evento.Infrastructure.Persistence.EF;

public sealed class DapperUnitOfWork : IUnitOfWork
{
    private readonly IDbTransaction _dbTransaction;
    private readonly IDomainEventHandler _domainEventHandler;

    public IUserRepository UserRepository { get; }
    public IPartyRepository PartyRepository { get; }
    public IOutboxMessageRepository OutboxMessageRepository { get; }

    public DapperUnitOfWork(
        IDbTransaction dbTransaction,
        IDomainEventHandler domainEventHandler,
        IUserRepository userRepository,
        IPartyRepository partyRepository,
        IOutboxMessageRepository outboxMessageRepository)
    {
        _dbTransaction = dbTransaction;
        _domainEventHandler = domainEventHandler;
        UserRepository = userRepository;
        PartyRepository = partyRepository;
        OutboxMessageRepository = outboxMessageRepository;
    }

    public async Task<int> CommitAsync<TEntity>(TEntity entity, 
                                                CancellationToken ct = default) 
        where TEntity : IEntity
    {
        try
        {
            await _domainEventHandler.HandleDomainEventsAsync(entity, OutboxMessageRepository, ct);

            _dbTransaction.Commit();
            _dbTransaction.Connection?.BeginTransaction();
        }
        catch
        {
            _dbTransaction.Rollback();
            throw;
        }

        return 1;
    }

    public void Dispose()
    {
        _dbTransaction.Connection?.Close();
        _dbTransaction.Connection?.Dispose();
        _dbTransaction.Dispose();
    }
}
