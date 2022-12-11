namespace Evento.Application.Exceptions;

public static class ErrorTypeExtensions
{
    public static Exception AsException(this ErrorType errorType, 
                                        string? message, 
                                        ErrorCode errorCode = ErrorCode.Common)
        => new EventoException(message, errorType, errorCode);
}
