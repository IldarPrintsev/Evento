namespace Evento.Domain.SeedWork;

public interface IDomainEvent 
{
    DateTimeOffset OccurredOn { get; }
}
