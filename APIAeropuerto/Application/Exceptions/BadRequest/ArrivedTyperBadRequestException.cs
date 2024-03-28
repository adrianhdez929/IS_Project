using APIAeropuerto.Application.Exceptions.BaseExceptions;

namespace APIAeropuerto.Application.Exceptions.BadRequest;

public class ArrivedTyperBadRequestException : BaseBadRequestExceptions
{
    public ArrivedTyperBadRequestException(string message) : base()
    {
        CustomCode = 400;
        CustomMessage = message;
    }
}