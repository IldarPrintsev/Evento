using Evento.Api.SeedWork;
using Evento.Application.Users.Commands.CreateUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Evento.Api.Users;

public class CreateUserEndpoint : IEndpoint
{
    public void InitializeRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("/api/users", CreateUserAsync)
           .AllowAnonymous()
           .WithName("CreateUser");
    }

    public record CreateUserRequest(string Username);

    public static async Task<IResult> CreateUserAsync(
        [FromBody] CreateUserRequest request,
        [FromServices] IMediator mediator,
        CancellationToken ct)
    {
        var command = new CreateUserCommand(request.Username);
        var result = await mediator.Send(command, ct);

        return Results.Ok(result);
    }
}
