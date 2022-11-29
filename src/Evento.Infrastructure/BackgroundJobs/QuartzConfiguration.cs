using Microsoft.Extensions.DependencyInjection;
using Quartz;

namespace Evento.Infrastructure.BackgroundJobs;

public static class QuartzConfiguration
{
    public static IServiceCollection AddQuartzJobs(this IServiceCollection services)
    {
        services.AddQuartz(configure =>
        {
            var jobKey = new JobKey(nameof(ProcessDomainEventsJob));

            configure.AddJob<ProcessDomainEventsJob>(jobKey)
                     .AddTrigger(trigger =>
                        trigger.ForJob(jobKey)
                               .WithSimpleSchedule(schedule =>
                                    schedule.WithIntervalInSeconds(20)
                                            .RepeatForever()));

            configure.UseMicrosoftDependencyInjectionJobFactory();
        });

        services.AddQuartzHostedService();

        return services;
    }
}
