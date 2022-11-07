using MediatR;

namespace Evento.Application.SeedWork;

public interface ICommandHandler<in TCommand, TResponse> 
    : IRequestHandler<TCommand, TResponse>
    where TCommand : ICommand<TResponse> { }
