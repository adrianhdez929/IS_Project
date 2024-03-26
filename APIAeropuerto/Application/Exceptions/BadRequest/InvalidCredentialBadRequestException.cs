using APIAeropuerto.Application.Exceptions.BaseExceptions;

namespace APIAeropuerto.Application.Exceptions.BadRequest;

public class InvalidCredentialBadRequestException : BaseBadRequestExceptions
{
    public InvalidCredentialBadRequestException(string msg) : base()
    {
        CustomCode = 400003;
        CustomMessage = msg;
    }
}