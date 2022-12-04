using Evento.Application.SeedWork;
using Evento.Domain.Parties;
using Evento.Infrastructure.Persistence;

namespace Evento.Application.Parties.Commands.CreateParty;

public sealed record CreatePartyCommand(string Title,
                                        DateTimeOffset StartedOn,
                                        DateTimeOffset FinishedOn,
                                        double Longitude,
                                        double Latitude,
                                        string? Description = null) 
    : ICommand<int>
{
    public sealed class CreatePartyCommandHandler
        : ICommandHandler<CreatePartyCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreatePartyCommandHandler(IUnitOfWork unitOfWork)
            => _unitOfWork = unitOfWork;

        public async Task<int> Handle(CreatePartyCommand request, CancellationToken cancellationToken)
        {
            var location = PartyLocation.Create(request.Longitude, request.Latitude);
            var time = PartyTime.Create(request.StartedOn, request.FinishedOn);
            var party = Party.Create(request.Title, time, location, request.Description);

            await _unitOfWork.PartyRepository.InsertAsync(party, cancellationToken);
            await _unitOfWork.CommitAsync(party, cancellationToken);

            return 0;
        }
    }
}
