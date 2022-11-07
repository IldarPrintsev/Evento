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

    internal static async Task<IResult> CreateUserAsync(
        [FromBody] CreateUserRequest request,
        [FromServices] ISender sender,
        CancellationToken ct)
    {
        var result = await sender.Send(request.ToCommand(), ct);

        return Results.Ok(result);
    }
}




