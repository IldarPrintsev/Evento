using Evento.Infrastructure.BackgroundJobs;
using Evento.Infrastructure.Persistence.Dapper;
using Evento.Infrastructure.Persistence.EF;
using Evento.Infrastructure.SharedKernel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Evento.Infrastructure;

public enum SqlORM
{
    EF,
    Dapper
};

public static class InfrastructureConfiguration
{
    public static IServiceCollection AddInfrastructure<TDomainEventPublisher>(
        this IServiceCollection services,
        IConfiguration configuration,
        string sqlConnectionString,
        SqlORM sqlORM) where TDomainEventPublisher : class, IDomainEventPublisher
    {
        switch (sqlORM)
        {
            case SqlORM.EF:
                services.AddEF(configuration, sqlConnectionString);
                break;
            case SqlORM.Dapper:
                services.AddDapper(configuration, sqlConnectionString);
                break;
            default:
                throw new InvalidOperationException($"{sqlORM} orm not implemented");
        }

        services.AddScoped<IDomainEventPublisher, TDomainEventPublisher>();

        services.AddQuartzJobs();

        return services;
    }
}
