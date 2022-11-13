using Evento.Application.SeedWork;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using ValidationException = FluentValidation.ValidationException;

namespace Evento.Application.Behaviors;

public sealed class ValidationPipelineBehavior<TRequest, TResponse> 
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : class, ICommand<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationPipelineBehavior(IEnumerable<IValidator<TRequest>> validators) 
        => _validators = validators;

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (!_validators.Any())
        {
            return await next();
        }

        var context = new ValidationContext<TRequest>(request);
        var failures = new List<ValidationFailure>();
        foreach(var validator in _validators)
        {
            var result = await validator.ValidateAsync(context, cancellationToken);
            failures.AddRange(result.Errors.Where(x => x != null));
        }

        return failures.Any() 
            ? throw new ValidationException(failures) 
            : await next();
    }
}
