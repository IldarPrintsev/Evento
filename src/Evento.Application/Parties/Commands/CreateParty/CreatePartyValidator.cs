using FluentValidation;

namespace Evento.Application.Parties.Commands.CreateParty;

public sealed class CreatePartyValidator
    : AbstractValidator<CreatePartyCommand>
{
    public CreatePartyValidator()
    {
        RuleFor(x => x.Title).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
        RuleFor(x => x.Longitude).NotEmpty();
        RuleFor(x => x.Latitude).NotEmpty();
        RuleFor(x => x.StartedOn).NotEmpty();
        RuleFor(x => x.FinishedOn).NotEmpty();
    }
}
