using System.Data;
using Evento.Infrastructure.Outbox;
using Evento.Infrastructure.Outbox.EF;
using Evento.Infrastructure.Persistence.EF;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Evento.Infrastructure.Persistence.Dapper;

public static class DapperConfiguration
{
    public static IServiceCollection AddDapper(
        this IServiceCollection services,
        IConfiguration configuration,
        string sqlConnectionString)
    {
        services.AddScoped(_
            => new SqlConnection(configuration.GetConnectionString(sqlConnectionString)));

        services.AddScoped<IDbTransaction>(s =>
        {
            var conn = s.GetRequiredService<SqlConnection>();
            conn.Open();
            return conn.BeginTransaction();
        });

        services.AddScoped<IUnitOfWork, DapperUnitOfWork>();

        services.AddScoped<IOutboxMessageRepository, OutboxMessageEfRepository>();

        return services;
    }
}
