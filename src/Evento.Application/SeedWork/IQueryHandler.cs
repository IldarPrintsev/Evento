using MediatR;

namespace Evento.Application.SeedWork;

public interface IQueryHandler<in TQuery, TResponse> 
    : IRequestHandler<TQuery, TResponse>
    where TQuery : IQuery<TResponse> { }
