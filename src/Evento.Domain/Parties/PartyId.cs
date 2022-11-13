using Evento.Domain.SeedWork;

namespace Evento.Domain.Parties;
public sealed class PartyId : TypedIdBase<Guid>
{
    public PartyId(Guid value) : base(value) { }

    public override string TextValue => Value.ToString();
}
