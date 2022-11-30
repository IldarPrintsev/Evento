using Evento.Domain.Parties;
using Evento.Domain.SeedWork;
using Evento.Infrastructure.Outbox;

namespace Evento.Infrastructure.Persistence;

public interface IUnitOfWork : IDisposable
{
    IOutboxMessageRepository OutboxMessageRepository { get; }
    IPartyRepository PartyRepository { get; }

    Task<int> CommitAsync<TEntity>(TEntity entity, CancellationToken ct = default)
        where TEntity : IEntity;
}
