using Evento.Domain.SeedWork;

namespace Evento.Domain.Parties;

public sealed class Party 
    : Entity<PartyId>, IAggregateRoot
{
    private Party(PartyId id) : base(id) { }

    public static Party Create(PartyId id)
    {
        var party = new Party(id);

        return party;
    }
}
