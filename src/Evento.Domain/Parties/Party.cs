using Evento.Domain.SeedWork;

namespace Evento.Domain.Parties;

public sealed class Party 
    : Entity<PartyId>, IAggregateRoot
{
    public string Title { get; }
    public string Description { get; }
    public PartyTime PartyTime { get; }
    public PartyLocation Location { get; }

    private Party(string title,
                  string description,
                  PartyTime partyTime,
                  PartyLocation location) 
        : base(new PartyId(Guid.NewGuid()))
    {
        Title = title;
        Description = description;
        PartyTime = partyTime;
        Location = location;
    }

    public static Party Create(string title,
                               string description,
                               PartyTime partyTime,
                               PartyLocation location)
    {
        var party = new Party(title,
                              description,
                              partyTime,
                              location);

        return party;
    }
}
