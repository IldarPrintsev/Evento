namespace Evento.Application.Exceptions;

public class EventoException : Exception
{
    public ErrorType ErrorType { get; }

    public ErrorCode ErrorCode { get; }

    public EventoException(string? message, 
                           ErrorType errorType, 
                           ErrorCode errorCode = ErrorCode.Common)
        : base(message)
        => (ErrorType, ErrorCode) = (errorType, errorCode);
}
