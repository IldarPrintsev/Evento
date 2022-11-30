using System.Reflection;

namespace Evento.Domain.SeedWork;

public abstract class ValueObject : DomainObject, IEquatable<ValueObject>
{
    private List<PropertyInfo>? _properties;
    private List<FieldInfo>? _fields;

    public static bool operator ==(ValueObject obj1, ValueObject obj2) 
        => Equals(obj1, null) ? Equals(obj2, null) : obj1.Equals(obj2);

    public static bool operator !=(ValueObject obj1, ValueObject obj2) 
        => !(obj1 == obj2);

    public bool Equals(ValueObject? other)
        => Equals(other as object);

    public override bool Equals(object? obj) 
        => obj != null 
           && GetType() == obj.GetType() 
           && GetProperties().All(p => PropertiesAreEqual(obj, p))
           && GetFields().All(f => FieldsAreEqual(obj, f));

    private bool PropertiesAreEqual(object? obj, PropertyInfo p) 
        => Equals(p.GetValue(this, null), p.GetValue(obj, null));

    private bool FieldsAreEqual(object? obj, FieldInfo f) 
        => Equals(f.GetValue(this), f.GetValue(obj));

    private IEnumerable<PropertyInfo> GetProperties()
    {
        _properties ??= GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public)
                                 .ToList();

        return _properties;
    }

    private IEnumerable<FieldInfo> GetFields()
    {
        _fields ??= GetType().GetFields(BindingFlags.Instance | BindingFlags.Public)
                             .ToList();

        return _fields;
    }

    public override int GetHashCode()
    {
        unchecked   //allow overflow
        {
            int hash = 17;
            foreach (var prop in GetProperties())
            {
                object? value = prop.GetValue(this, null);
                hash = HashValue(hash, value);
            }

            foreach (var field in GetFields())
            {
                object? value = field.GetValue(this);
                hash = HashValue(hash, value);
            }

            return hash;
        }
    }

    private static int HashValue(int seed, object? value) 
        => (seed * 23) + (value?.GetHashCode() ?? 0);
}