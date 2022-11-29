using Evento.Application.DomainEvents;
using Evento.Domain.Users;
using MediatR;

namespace Evento.Application.Users.Commands.CreateUser;

public class UserCreatedNotificationHandler 
    : INotificationHandler<DomainEventNotification<UserCreated>>
{
    public Task Handle(DomainEventNotification<UserCreated> notification, CancellationToken cancellationToken) 
        => throw new NotImplementedException();
}
