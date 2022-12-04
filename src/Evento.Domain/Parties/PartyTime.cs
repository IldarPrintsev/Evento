using Evento.Domain.Parties.Rules;
using Evento.Domain.SeedWork;

namespace Evento.Domain.Parties;

public sealed class PartyTime : ValueObject
{
    public DateTimeOffset StartedOn { get; }
    public DateTimeOffset FinishedOn { get; }

    private PartyTime(DateTimeOffset startedOn, DateTimeOffset finishedOn) 
        => (StartedOn, FinishedOn) = (startedOn, finishedOn);

    public static PartyTime Create(DateTimeOffset startedOn, DateTimeOffset finishedOn)
    {
        EnsureRule(new PartyTimeRule(startedOn, finishedOn));

        return new(startedOn, finishedOn);
    }
}
