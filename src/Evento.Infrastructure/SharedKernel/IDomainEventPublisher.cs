using Evento.Domain.SeedWork;

namespace Evento.Infrastructure.SharedKernel;

public interface IDomainEventPublisher
{
    Task PublishAsync(IDomainEvent domainEvent, CancellationToken ct = default);
}
