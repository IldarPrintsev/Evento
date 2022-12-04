using Evento.Domain.SeedWork;
using Evento.Domain.SharedKernel;

namespace Evento.Domain.Users;

public sealed class UserCreated : IDomainEvent
{
    public DateTimeOffset OccurredOn => SystemClock.Now;
    public UserEmail UserEmail { get; }

    public UserCreated(UserEmail userEmail) 
        => UserEmail = userEmail;
}
