using Evento.Domain.Users;

namespace SampleProject.Domain.Customers;

public interface IUserUniquenessChecker
{
    Task<bool> VerifyAsync(UserEmail userEmail);
}