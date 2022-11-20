namespace Evento.Infrastructure.DomainEvents.Processor;

public interface IDomainEventProcessor
{
    Task ProcessAsync(int eventAmount = 20, CancellationToken ct = default);
}
