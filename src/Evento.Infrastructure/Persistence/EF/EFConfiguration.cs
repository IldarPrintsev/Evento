using Evento.Domain.Parties;
using Evento.Domain.Users;
using Evento.Infrastructure.Outbox;
using Evento.Infrastructure.Outbox.EF;
using Evento.Infrastructure.Parties.EF;
using Evento.Infrastructure.Users.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SampleProject.Domain.Customers;

namespace Evento.Infrastructure.Persistence.EF;

public static class EFConfiguration
{
    public static IServiceCollection AddEF(
        this IServiceCollection services, 
        IConfiguration configuration,
        string sqlConnectionString)
    {
        services.AddDbContext<EventoContext>(opts =>
        {
            opts.UseSqlServer(configuration.GetConnectionString(sqlConnectionString));
            opts.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        });

        services.AddScoped<IUnitOfWork, EFUnitOfWork>();
        services.AddScoped<IUserRepository, UserEFRepository>();
        services.AddScoped<IPartyRepository, PartyEFRepository>();
        services.AddScoped<IOutboxMessageRepository, OutboxMessageEfRepository>();

        services.AddScoped<IUserUniquenessChecker, UserUniquenessEFChecker>();

        return services;
    }
}
