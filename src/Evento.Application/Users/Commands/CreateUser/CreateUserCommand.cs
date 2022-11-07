using Evento.Application.SeedWork;

namespace Evento.Application.Users.Commands.CreateUser;

public sealed record CreateUserCommand(
    string? Username
    ) : ICommand<int>
{
    public sealed class CreateUserCommandHandler
        : ICommandHandler<CreateUserCommand, int>
    {
        public CreateUserCommandHandler()
        {

        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            return 0;
        }
    }
}
