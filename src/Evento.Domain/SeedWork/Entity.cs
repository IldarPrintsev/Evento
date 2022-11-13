namespace Evento.Domain.SeedWork;

public abstract class Entity<TId>
    : IEquatable<Entity<TId>> 
    where TId : ITypedId
{
    public TId Id { get; protected set; }
    public DateTime Created { get; protected set; }
    public string? CreatedBy { get; protected set; }
    public DateTime? LastModified { get; protected set; }
    public string? LastModifiedBy { get; protected set; }

    protected Entity(TId id)
    {
        Id = id;
        Created = DateTime.UtcNow;
    }

    public override bool Equals(object? obj)
        => obj is Entity<TId> entity && Equals(entity);

    public bool Equals(Entity<TId>? other)
        => other is not null && Id.Equals(other.Id);

    public static bool operator ==(Entity<TId> left, Entity<TId> right)
        => left.Equals(right);

    public static bool operator !=(Entity<TId> left, Entity<TId> right)
        => !left.Equals(right);

    public override int GetHashCode()
        => Id.GetHashCode();

    protected static void ValidateRuleAndThrow(IBusinessRule rule)
    {
        if (rule.IsBroken())
        {
            throw new BusinessRuleValidationException(rule);
        }
    }

    protected static bool ValidateRule(IBusinessRule rule)
        => rule.IsBroken();
}
