using Mapster;
using MediatR;

namespace Evento.Api.SeedWork;
public abstract record BaseHttpRequest<TMediatorRequest> : IRegister
    where TMediatorRequest : IBaseRequest
{
    public TMediatorRequest ToCommand() 
        => this.Adapt<TMediatorRequest>();

    public void Register(TypeAdapterConfig config)
    {
        AddCustomMappings();
    }

    protected virtual void AddCustomMappings() { }

    protected TypeAdapterSetter<TSource, TMediatorRequest> SetCustomMappings<TSource>()
        => TypeAdapterConfig.GlobalSettings.ForType<TSource, TMediatorRequest>();
}
