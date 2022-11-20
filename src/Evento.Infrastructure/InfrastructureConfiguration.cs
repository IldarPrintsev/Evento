using Evento.Infrastructure.Persistence.Dapper;
using Evento.Infrastructure.Persistence.EF;
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
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration,
        string sqlConnectionString,
        SqlORM sqlORM = SqlORM.EF)
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

        return services;
    }
}
