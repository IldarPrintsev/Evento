using Evento.Domain.Parties;
using Evento.Infrastructure.Persistence.EF;

namespace Evento.Infrastructure.Parties.EF;

public class PartyEFRepository : IPartyRepository
{
    private readonly EventoContext _context;

    public PartyEFRepository(EventoContext context)
        => _context = context;

    public Task InsertAsync(Party party, CancellationToken ct = default) 
        => throw new NotImplementedException();
}
