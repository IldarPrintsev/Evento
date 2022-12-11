using Evento.Domain.SeedWork;
using SampleProject.Domain.Customers;

namespace Evento.Domain.Users.Rules;

public class UserUniquenessAsyncRule : IAsyncBusinessRule
{
    private readonly UserEmail _userEmail;
    private readonly IUserUniquenessChecker _checker;

    public UserUniquenessAsyncRule(UserEmail userEmail, IUserUniquenessChecker checker)
        => (_userEmail, _checker) = (userEmail, checker);

    public string Message
        => $"Email {_userEmail} is already in use.";

    public async Task<bool> VerifyAsync(CancellationToken ct = default)
        => await _checker.VerifyAsync(_userEmail, ct);
}
