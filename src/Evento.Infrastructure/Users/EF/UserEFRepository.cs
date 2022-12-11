using Evento.Domain.Users;
using Evento.Infrastructure.Persistence.EF;

namespace Evento.Infrastructure.Users.EF;

public class UserEFRepository : IUserRepository
{
    private readonly EventoContext _context;

    public UserEFRepository(EventoContext context)
        => _context = context;

    public Task InsertAsync(User user, CancellationToken ct = default) 
        => throw new NotImplementedException();
}
