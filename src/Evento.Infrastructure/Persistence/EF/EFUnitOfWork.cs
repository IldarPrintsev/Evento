using Evento.Domain.Parties;
using Evento.Domain.SeedWork;
using Evento.Domain.Users;
using Evento.Infrastructure.DomainEvents.Handler;
using Evento.Infrastructure.Outbox;

namespace Evento.Infrastructure.Persistence.EF;

public sealed class EFUnitOfWork : IUnitOfWork
{
    private readonly EventoContext _context;
    private readonly IDomainEventHandler _domainEventHandler;

    public IUserRepository UserRepository { get; }
    public IPartyRepository PartyRepository { get; }
    public IOutboxMessageRepository OutboxMessageRepository { get; }

    public EFUnitOfWork(
        EventoContext context,
        IDomainEventHandler domainEventHandler,
        IUserRepository userRepository,
        IPartyRepository partyRepository,
        IOutboxMessageRepository outboxMessageRepository)
    {
        _context = context;
        _domainEventHandler = domainEventHandler;
        UserRepository = userRepository;
        PartyRepository = partyRepository;
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
