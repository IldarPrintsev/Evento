using MediatR;

namespace Evento.Application.SeedWork;

public interface ICommand<out TResponse> : IRequest<TResponse> { }
