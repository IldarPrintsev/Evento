using Evento.Domain.Users;
using Evento.Infrastructure.Persistence.EF;
using Microsoft.EntityFrameworkCore;
using SampleProject.Domain.Customers;

namespace Evento.Infrastructure.Users.EF;

public class UserUniquenessEFChecker : IUserUniquenessChecker
{
    private readonly EventoContext _context;

    public UserUniquenessEFChecker(EventoContext context)
        => _context = context;

    public async Task<bool> VerifyAsync(UserEmail userEmail, CancellationToken ct = default) 
        => !await _context.Users.AnyAsync(x => x.Email.Equals(userEmail), ct);
}
