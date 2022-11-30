﻿namespace Evento.Domain.SeedWork;

public abstract class DomainObject
{
    protected static void EnsureRule(ISyncBusinessRule rule)
    {
        bool isVerified = rule.Verify();
        if (!isVerified)
        {
            throw new BusinessRuleValidationException(rule);
        }
    }

    protected static async Task EnsureRuleAsync(IAsyncBusinessRule rule)
    {
        bool isVerified = await rule.VerifyAsync();
        if (!isVerified)
        {
            throw new BusinessRuleValidationException(rule);
        }
    }
}
