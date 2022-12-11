using Evento.Domain.SeedWork;
using Evento.Domain.Users.Rules;

namespace Evento.Domain.Users;

public sealed class UserEmail : ValueObject
{
    public string Value { get; }

    private UserEmail(string value)
        => Value = value.ToLower();

    public static UserEmail Create(string email)
    {
        EnsureRule(new UserEmailRule(email));

        return new(email);
    }
}
