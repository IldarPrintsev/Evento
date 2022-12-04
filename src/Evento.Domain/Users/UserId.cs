using Evento.Domain.SeedWork;

namespace Evento.Domain.Parties;

public sealed class UserId : TypedIdBase<Guid>
{
    public UserId(Guid value) : base(value, value.ToString()) { }
}
