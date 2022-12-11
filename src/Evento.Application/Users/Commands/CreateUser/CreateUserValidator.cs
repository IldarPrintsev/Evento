using FluentValidation;

namespace Evento.Application.Users.Commands.CreateUser;

public sealed class CreateUserCommandValidator 
    : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator() 
        => RuleFor(x => x.Email).NotEmpty();
}
