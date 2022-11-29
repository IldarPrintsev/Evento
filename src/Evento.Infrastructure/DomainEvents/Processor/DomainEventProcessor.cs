using Evento.Infrastructure.DomainEvents.Handler;
using Evento.Infrastructure.Persistence;
using Evento.Infrastructure.SharedKernel;

namespace Evento.Infrastructure.DomainEvents.Processor;

public sealed class DomainEventProcessor : IDomainEventProcessor
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDomainEventHandler _domainEventHandler;
    private readonly IDomainEventPublisher _domainEventPublisher;

    public DomainEventProcessor(
        IUnitOfWork unitOfWork,
        IDomainEventHandler domainEventHandler,
        IDomainEventPublisher domainEventPublisher)
    {
        _unitOfWork = unitOfWork;
        _domainEventHandler = domainEventHandler;
        _domainEventPublisher = domainEventPublisher;
    }

    public async Task ProcessAsync(int eventAmount = 20, CancellationToken ct = default)
    {
        var domainEvents = await _domainEventHandler.FetchDomainEventsAsync(
            _unitOfWork.OutboxMessageRepository, 
            eventAmount, 
            ct);

        if (domainEvents is null || !domainEvents.Any())
        {
            return;
        }

        var tasks = domainEvents.Select(async (domainEvent) 
            => await _domainEventPublisher.PublishAsync(domainEvent, ct));

        await Task.WhenAll(tasks);
    }
}
