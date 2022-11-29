namespace Evento.Domain.SeedWork;

public abstract class Entity<TId>
    : IEntity, IEquatable<Entity<TId>>
    where TId : ITypedId
{
    private readonly List<IDomainEvent> _domainEvents = new();

    public TId Id { get; protected set; }
    public DateTime CreatedOn { get; protected set; }
    public string? CreatedBy { get; protected set; }
    public DateTime? LastModifiedOn { get; protected set; }
    public string? LastModifiedBy { get; protected set; }
    public IReadOnlyCollection<IDomainEvent> DomainEvents
       => _domainEvents.AsReadOnly();

    protected Entity(TId id) 
        => (Id, CreatedOn) = (id, DateTime.UtcNow);

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

    public void ClearDomainEvents() 
        => _domainEvents.Clear();

    protected static void EnsureRule(ISyncBusinessRule rule)
    {
        bool isVerified = rule.Verify();
        if (!isVerified)
        {
            throw new BusinessRuleValidationException(rule);
        }
    }

    protected static async Task EnsureRuleAsync(IAsyncBusinessRule rule)
    {
        bool isVerified = await rule.VerifyAsync();
        if (!isVerified)
        {
            throw new BusinessRuleValidationException(rule);
        }
    }

    protected void AddDomainEvent(IDomainEvent domainEvent) 
        => _domainEvents.Add(domainEvent);
}
