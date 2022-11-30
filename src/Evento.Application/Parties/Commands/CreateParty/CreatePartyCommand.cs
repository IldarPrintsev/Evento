using Evento.Application.SeedWork;
using Evento.Domain.Parties;
using Evento.Infrastructure.Persistence;

namespace Evento.Application.Parties.Commands.CreateParty;

public sealed record CreatePartyCommand(
    string? Title,
    string? Description,
    DateTimeOffset? StartedOn,
    DateTimeOffset? FinishedOn,
    double? Longitude,
    double? Latitude
    ) : ICommand<int>
{
    public sealed class CreatePartyCommandHandler
        : ICommandHandler<CreatePartyCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreatePartyCommandHandler(IUnitOfWork unitOfWork)
            => _unitOfWork = unitOfWork;

        public async Task<int> Handle(CreatePartyCommand request, CancellationToken cancellationToken)
        {
            var location = PartyLocation.Create(request.Longitude!.Value, request.Latitude!.Value);
            var time = PartyTime.Create(request.StartedOn!.Value, request.FinishedOn!.Value);
            var party = Party.Create(request.Title!, request.Description!, time, location);

            await _unitOfWork.PartyRepository.InsertAsync(party, cancellationToken);
            await _unitOfWork.CommitAsync(party, cancellationToken);

            return 0;
        }
    }
}
