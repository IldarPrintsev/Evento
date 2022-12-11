namespace Evento.Application.Exceptions;

public static class ErrorTypeExtensions
{
    public static EventoException AsException(this ErrorType errorType, 
                                        string? message, 
                                        ErrorCode errorCode = ErrorCode.Common)
        => new(message, errorType, errorCode);
}
