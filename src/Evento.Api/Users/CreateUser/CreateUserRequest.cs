using Evento.Api.SeedWork;
using Evento.Application.Users.Commands.CreateUser;

namespace Evento.Api.Users.CreateUser;

public sealed record CreateUserRequest
        : BaseHttpRequest<CreateUserCommand>
{
    public string Email { get; init; } = default!;

    protected override void AddCustomMappings() 
        => SetCustomMappings<CreateUserRequest>()
            .Map(dest => dest.Email, src => src.Email);
}
