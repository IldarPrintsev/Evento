using Evento.Infrastructure.Outbox;
using Evento.Infrastructure.Outbox.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Evento.Infrastructure.Persistence.EF;

public static class EFConfiguration
{
    public static IServiceCollection AddEF(
        this IServiceCollection services, 
        IConfiguration configuration,
        string sqlConnectionString)
    {
        services.AddDbContext<EventoContext>(opts 
            => opts.UseSqlServer(configuration.GetConnectionString(sqlConnectionString)));

        services.AddScoped<IUnitOfWork, EFUnitOfWork>();

        services.AddScoped<IOutboxMessageRepository, OutboxMessageEfRepository>();

        return services;
    }
}
