using Evento.Api.SeedWork;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Evento.Api.Users.CreateUser;

public sealed class CreateUserEndpoint : IEndpoint
{
    public void Setup(IEndpointRouteBuilder app) 
        => app.MapPost("/api/users", CreateUserAsync)
              .AllowAnonymous()
              .WithName("CreateUser");

    internal static async Task<IResult> CreateUserAsync(
        [FromBody] CreateUserRequest request,
        [FromServices] ISender sender,
        CancellationToken ct)
    {
        int result = await sender.Send(request.ToCommand(), ct);

        return Results.Ok(result);
    }
}