namespace Evento.Domain.SeedWork;

public abstract class TypedIdBase<TValue>
    : ITypedId, IEquatable<TypedIdBase<TValue>>
    where TValue : notnull
{
    public TValue Value { get; }
    public string TextValue { get; }

    protected TypedIdBase(TValue value, string textValue) 
        => (Value, TextValue) = (value, textValue);

    public override bool Equals(object? obj)
        => obj is TypedIdBase<TValue> entity && Equals(entity);

    public bool Equals(TypedIdBase<TValue>? other)
        => other is not null && Value.Equals(other.Value);

    public static bool operator ==(TypedIdBase<TValue> left, TypedIdBase<TValue> right)
        => left.Equals(right);

    public static bool operator !=(TypedIdBase<TValue> left, TypedIdBase<TValue> right)
        => !left.Equals(right);

    public override int GetHashCode()
        => Value.GetHashCode();

    public override string ToString() 
        => TextValue;
}
