using Evento.Api.SeedWork;
using Mapster;

namespace Evento.Api.Configuration.WebApplicationBuilder;

public static class MapsterConfiguration
{
    public static void AddMapster(this IServiceCollection services)
    {
        TypeAdapterConfig.GlobalSettings.Scan(typeof(BaseHttpRequest<>).Assembly);
    }
}
