namespace Evento.Domain.Users;

public interface IUserRepository
{
    Task InsertAsync(User user, CancellationToken ct = default);
}
