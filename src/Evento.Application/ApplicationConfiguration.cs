using Evento.Application.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Evento.Application;

public static class ApplicationConfiguration
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediator();

        return services;
    }
}
