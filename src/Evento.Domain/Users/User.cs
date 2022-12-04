using Evento.Domain.Parties;
using Evento.Domain.SeedWork;
using Evento.Domain.Users.Rules;
using SampleProject.Domain.Customers;

namespace Evento.Domain.Users;

public sealed class User
    : Entity<UserId>, IAggregateRoot
{
    public UserEmail Email { get; private set; }

    private User(UserEmail email)
        : base(new UserId(Guid.NewGuid()))
    {
        Email = email;
        AddDomainEvent(new UserCreated(email));
    }

    public static async Task<User> CreateAsync(UserEmail email, 
                                               IUserUniquenessChecker checker, 
                                               CancellationToken ct = default)
    {
        await EnsureRuleAsync(new UserUniquenessAsyncRule(email, checker), ct);

        return new(email);
    }
}
