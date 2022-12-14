using Evento.Application.Configuration;
using Evento.Application.DomainEvents;
using Evento.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Evento.Application;

public static class ApplicationConfiguration
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services,
        IConfiguration configuration,
        string sqlConnectionString)
    {
        services.AddMediator();

        services.AddInfrastructure<DomainEventsMediatorPublisher>(
            configuration, 
            sqlConnectionString, 
            SqlORM.EF);

        return services;
    }
}
