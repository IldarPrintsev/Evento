using MediatR;

namespace Evento.Application.Users.Commands.CreateUser;

public record CreateUserCommand(string? Username) 
    : IRequest<int> 
{ 
    public class CreateUserCommandHandler 
        : IRequestHandler<CreateUserCommand, int>
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
