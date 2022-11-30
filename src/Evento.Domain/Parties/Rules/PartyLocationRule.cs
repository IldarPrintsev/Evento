using Evento.Domain.SeedWork;

namespace Evento.Domain.Parties.Rules;

public class PartyLocationRule : ISyncBusinessRule
{
    private const double MinLongitude = -25;
    private const double MaxLongitude = 65;
    private const double MinLatitude = 35;
    private const double MaxLatitude = 72;

    private readonly double _longitude;
    private readonly double _latitude;
    

    public PartyLocationRule(double longitude, double latitude)
        => (_longitude, _latitude) = (longitude, latitude);

    public string Message 
        => @$"The location must be in Europe. 
             Europe lies between the latitudes {MinLatitude} to {MaxLatitude} and the longitudes {MinLongitude} to {MaxLongitude}";

    public bool Verify() 
        => _latitude >= MinLatitude 
           && _latitude <= MaxLatitude
           && _longitude >= MinLongitude
           && _longitude <= MaxLongitude;
}
