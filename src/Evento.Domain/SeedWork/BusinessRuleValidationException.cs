namespace Evento.Domain.SeedWork;

public class BusinessRuleValidationException : Exception
{
    public BusinessRuleValidationException(IBusinessRule brokenRule) 
        : base(brokenRule.Message)
    {
        BrokenRule = brokenRule;
        Details = brokenRule.Message;
    }

    public IBusinessRule BrokenRule { get; }

    public string Details { get; }

    public override string ToString() 
        => $"{BrokenRule.GetType().FullName}: {BrokenRule.Message}";
}
