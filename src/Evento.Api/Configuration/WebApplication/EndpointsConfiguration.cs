using Evento.Api.SeedWork;
using System.Reflection;

namespace Evento.Api.Configuration.WebApplication;

public static class EndpointsConfiguration
{
    public static IEndpointRouteBuilder UseCustomEndpoints(this IEndpointRouteBuilder routeBuilder)
    {
        var endpoints = Assembly.GetExecutingAssembly()
            .ExportedTypes
            .Where(type => typeof(IEndpoint).IsAssignableFrom(type) && type.IsClass)
            .Select(e => Activator.CreateInstance(e)).Cast<IEndpoint>();

        foreach (var endpoint in endpoints)
        {
            endpoint.Setup(routeBuilder);
        }

        return routeBuilder;
    }
}
