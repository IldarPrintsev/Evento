using System.Diagnostics;
using Evento.Application.SeedWork;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Evento.Application.Behaviors;

public sealed class LoggingPipelineBehavior<TRequest, TResponse>
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : class, ICommand<TResponse>
{
    private readonly ILogger<LoggingPipelineBehavior<TRequest, TResponse>> _logger;

    public LoggingPipelineBehavior(ILogger<LoggingPipelineBehavior<TRequest, TResponse>> logger)
        => _logger = logger;

    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken ct)
    {
        TResponse response;
        string requestName = typeof(TRequest).Name;
        string unqiueId = Guid.NewGuid().ToString();
        var timer = new Stopwatch();
        timer.Start();
        try
        {
            _logger.LogInformation(
                "Request executing. Id: {@UniqueId}. Name: {@RequestName}. Payload: {@Request}.",
                unqiueId,
                requestName,
                request);

            response = await next();

            timer.Stop();
            _logger.LogInformation(
                "Request succeded. Id: {@UniqueId}. Name: {@RequestName}. Time: {@ElapsedMilliseconds}ms",
                unqiueId,
                requestName,
                timer.ElapsedMilliseconds);
        }
        catch (Exception exception)
        {
            timer.Stop();
            _logger.LogError(
                exception,
                "Request failed. Id: {@UniqueId}. Name: {@RequestName}. Time: {@ElapsedMilliseconds}ms",
                unqiueId,
                requestName,
                timer.ElapsedMilliseconds);

            throw;
        }

        return response;
    }
}
