using Evento.Domain.Parties.Rules;
using Evento.Domain.SeedWork;

namespace Evento.Domain.Parties;

public sealed class PartyLocation : ValueObject
{
    public double Longitude { get; }
    public double Latitude { get; }

    private PartyLocation(double longitude, double latitude)
        => (Longitude, Latitude) = (longitude, latitude);

    public static PartyLocation Create(double longitude, double latitude)
    {
        EnsureRule(new PartyLocationRule(longitude, latitude));

        return new(longitude, latitude);
    }
}
