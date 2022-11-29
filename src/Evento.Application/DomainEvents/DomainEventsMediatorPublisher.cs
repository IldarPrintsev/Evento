using Evento.Domain.SeedWork;
using Evento.Infrastructure.SharedKernel;
using MediatR;

namespace Evento.Application.DomainEvents;

public class DomainEventsMediatorPublisher : IDomainEventPublisher
{
    private readonly IPublisher _publisher;

    public DomainEventsMediatorPublisher(IPublisher publisher)
        => _publisher = publisher;

    public async Task PublishAsync(IDomainEvent domainEvent, CancellationToken ct = default)
    {
        var genericDispatcherType = typeof(DomainEventNotification<>).MakeGenericType(domainEvent.GetType());
        if (Activator.CreateInstance(genericDispatcherType, domainEvent) is not INotification notification)
        {
            return;
        }

        await _publisher.Publish(notification, ct);
    }
}
