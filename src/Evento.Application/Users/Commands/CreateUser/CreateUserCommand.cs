using Evento.Application.SeedWork;
using Evento.Domain.Users;
using Evento.Infrastructure.Persistence;
using SampleProject.Domain.Customers;

namespace Evento.Application.Users.Commands.CreateUser;

public sealed record CreateUserCommand(string Email) 
    : ICommand<int>
{
    public sealed class CreateUserCommandHandler
        : ICommandHandler<CreateUserCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserUniquenessChecker _userUniquenessChecker;

        public CreateUserCommandHandler(IUnitOfWork unitOfWork, 
                                        IUserUniquenessChecker userUniquenessChecker)
        {
            _unitOfWork = unitOfWork;
            _userUniquenessChecker = userUniquenessChecker;
        }

        public async Task<int> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var userEmail = UserEmail.Create(request.Email);
            var user = await User.CreateAsync(userEmail, _userUniquenessChecker, cancellationToken);
            
            await _unitOfWork.UserRepository.InsertAsync(user, cancellationToken);
            await _unitOfWork.CommitAsync(user, cancellationToken);

            return 0;
        }
    }
}
