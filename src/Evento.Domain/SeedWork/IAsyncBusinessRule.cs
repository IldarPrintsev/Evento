namespace Evento.Domain.SeedWork;

public interface IAsyncBusinessRule : IBusinessRule
{
    Task<bool> VerifyAsync();
}
