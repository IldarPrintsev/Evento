using Evento.Domain.SeedWork;

namespace Evento.Domain.Users;

public class UserCreated : IDomainEvent
{
    public DateTime OccurredOn => DateTime.UtcNow;
}
