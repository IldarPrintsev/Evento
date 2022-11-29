namespace Evento.Domain.SeedWork;

public interface ISyncBusinessRule : IBusinessRule
{
    bool Verify();
}
