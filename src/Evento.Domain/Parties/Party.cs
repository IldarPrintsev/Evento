using Evento.Domain.SeedWork;

namespace Evento.Domain.Parties;

public sealed class Party
    : Entity<PartyId>, IAggregateRoot
{
    public string Title { get; private set; }
    public PartyTime PartyTime { get; private set; }
    public PartyLocation Location { get; private set; }
    public string? Description { get; private set; }

    private Party(string title,
                  PartyTime partyTime,
                  PartyLocation location,
                  string? description)
        : base(new PartyId(Guid.NewGuid()))
    {
        Title = title;
        Description = description;
        PartyTime = partyTime;
        Location = location;
    }

    public static Party Create(string title,
                               PartyTime partyTime,
                               PartyLocation location,
                               string? description = null) 
        => new(title,
               partyTime,
               location,
               description);

    public void Update(string title,
                       PartyTime partyTime,
                       PartyLocation location,
                       string? description = null)
    {
        Title = title;
        Description = description;
        PartyTime = partyTime;
        Location = location;
    }
}
