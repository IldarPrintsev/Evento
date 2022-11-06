using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Net.Http.Json;
using Evento.Api.Users.CreateUser;
using static Evento.Api.Users.CreateUser.CreateUserEndpoint;

namespace Evento.UnitTests.Api.Users;

[ExcludeFromCodeCoverage]
public class CreateUserEndpointTests
{
    [Fact]
    public async Task CreateUserAsync_NewUserValidRequest_Ok()
    {
        await using var application = new
            WebApplicationFactory<Program>();
        using var client = application.CreateClient();

        var response = await client.PostAsJsonAsync("/api/users", new CreateUserRequest("1"));
        
        var result = await response.Content.ReadFromJsonAsync<int>();
        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.InRange(result, 1, int.MaxValue);
    }
}