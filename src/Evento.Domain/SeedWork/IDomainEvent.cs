namespace Evento.Domain.SeedWork;

public interface IDomainEvent 
{
    DateTime OccurredOn { get; }
}
