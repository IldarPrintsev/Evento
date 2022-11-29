using Evento.Infrastructure.DomainEvents.Processor;
using Quartz;

namespace Evento.Infrastructure.BackgroundJobs;

[DisallowConcurrentExecution]
public class ProcessDomainEventsJob : IJob
{
    private readonly IDomainEventProcessor _eventProcessor;

    public ProcessDomainEventsJob(IDomainEventProcessor eventProcessor)
        => _eventProcessor = eventProcessor;

    public async Task Execute(IJobExecutionContext context)
        => await _eventProcessor.ProcessAsync(20, context.CancellationToken);
}
