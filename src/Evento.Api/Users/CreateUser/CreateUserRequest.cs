using Evento.Api.SeedWork;
using Evento.Application.Users.Commands.CreateUser;

namespace Evento.Api.Users.CreateUser;

public sealed record CreateUserRequest
        : BaseHttpRequest<CreateUserCommand>
{
    public string? Username { get; init; }

    protected override void AddCustomMappings() 
        => SetCustomMappings<CreateUserRequest>()
            .Map(dest => dest.Username, src => src.Username);
}
