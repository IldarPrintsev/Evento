using MediatR;

namespace Evento.Application.SeedWork;

public interface IQuery<out TResponse> : IRequest<TResponse> { }
