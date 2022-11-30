namespace Evento.Domain.Parties;

public interface IPartyRepository
{
    Task InsertAsync(Party party, CancellationToken ct = default);
}
