using Evento.Application.Exceptions;
using Evento.Application.SeedWork;
using Evento.Domain.SeedWork;
using FluentValidation;
using MediatR;

namespace Evento.Application.Behaviors;

public sealed class ExceptionPipelineBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : class, ICommand<TResponse>
{
    public async Task<TResponse> Handle(TRequest request,
                                        RequestHandlerDelegate<TResponse> next,
                                        CancellationToken ct)
    {
        TResponse response;
        try
        {
            response = await next();
        }
        catch (EventoException)
        {
            throw;
        }
        catch (BusinessRuleValidationException ex)
        {
            throw ErrorType.BusinessRule.AsException(ex.Message);
        }
        catch (ValidationException ex)
        {
            throw ErrorType.Validation.AsException(ex.Message);
        }
        catch (Exception ex)
        {
            throw ErrorType.Internal.AsException(ex.Message);
        }

        return response;
    }
}
