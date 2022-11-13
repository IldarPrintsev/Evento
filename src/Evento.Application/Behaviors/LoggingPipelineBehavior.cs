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
                "Begin Request Id: {UniqueId}, request name: {RequestName}",
                unqiueId,
                requestName);

            response = await next();
        }
        catch
        {
            throw;
        }
        finally
        {
            timer.Stop();
            _logger.LogInformation(
                "Finish Request Id: {UnqiueId}, request name: {RequestName}, total request time: {ElapsedMilliseconds}ms",
                unqiueId,
                requestName,
                timer.ElapsedMilliseconds);
        }

        return response;
    }
}
