using Evento.Domain.Parties;
using Evento.Domain.SeedWork;
using Evento.Domain.Users;
using Evento.Infrastructure.Outbox;

namespace Evento.Infrastructure.Persistence;

public interface IUnitOfWork : IDisposable
{
    IUserRepository UserRepository { get; }
    IPartyRepository PartyRepository { get; }
    IOutboxMessageRepository OutboxMessageRepository { get; }
    
    Task<int> CommitAsync<TEntity>(TEntity entity, CancellationToken ct = default)
        where TEntity : IEntity;
}
