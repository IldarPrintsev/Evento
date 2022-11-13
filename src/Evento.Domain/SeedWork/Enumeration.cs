using System.Reflection;

namespace Evento.Domain.SeedWork;

public abstract class Enumeration : IComparable
{
    public int Id { get; }
    public string Name { get; }

    protected Enumeration(int id, string name) 
        => (Id, Name) = (id, name);

    public static IEnumerable<T> GetAll<T>() 
        where T : Enumeration 
        => typeof(T).GetFields(BindingFlags.Public |
                               BindingFlags.Static |
                               BindingFlags.DeclaredOnly)
                    .Select(f => f.GetValue(null))
                    .Cast<T>();

    public override bool Equals(object? obj)
    {
        if (obj is not Enumeration other)
        {
            return false;
        }

        bool typeMatches = GetType().Equals(other.GetType());
        bool valueMatches = Id.Equals(other.Id);

        return typeMatches && valueMatches;
    }

    public override string ToString()
       => Name;

    public override int GetHashCode() 
        => base.GetHashCode();

    public int CompareTo(object? other)
    {
        ArgumentNullException.ThrowIfNull(other);

        return Id.CompareTo(((Enumeration)other).Id);
    }
}
