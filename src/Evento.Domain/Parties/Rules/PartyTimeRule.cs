using Evento.Domain.SeedWork;
using Evento.Domain.SharedKernel;

namespace Evento.Domain.Parties.Rules;

public class PartyTimeRule : ISyncBusinessRule
{
    private readonly DateTimeOffset _startedOn;
    private readonly DateTimeOffset _finishedOn;
    
    public PartyTimeRule(DateTimeOffset startedOn, DateTimeOffset finishedOn)
        => (_startedOn, _finishedOn) = (startedOn, finishedOn);

    public string Message 
        => "The dates are wrong. Both dates must be in the future. FinishedOn must be later than StartedOn.";

    public bool Verify()
    {
        var now = SystemClock.Now;

        return _startedOn > now && _finishedOn > now && _finishedOn > _startedOn;
    }
}
