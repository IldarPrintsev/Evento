using Evento.Api.SeedWork;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Evento.Api.Users.CreateUser;

public class CreateUserEndpoint : IEndpoint
{
    public void Setup(IEndpointRouteBuilder app)
    {
        app.MapPost("/api/users", CreateUserAsync)
           .AllowAnonymous()
           .WithName("CreateUser");
    }

    public static async Task<IResult> CreateUserAsync(
        [FromBody] CreateUserRequest request,
        [FromServices] IMediator mediator,
        CancellationToken ct)
    {
        var result = await mediator.Send(request.ToCommand(), ct);

        return Results.Ok(result);
    }
}




