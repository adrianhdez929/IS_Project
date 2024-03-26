using APIAeropuerto.Application.Exceptions.BaseExceptions;

namespace APIAeropuerto.Application.Exceptions.BadRequest;

public class CreatingTokenBadRequestException : BaseBadRequestExceptions
{
    public CreatingTokenBadRequestException(string msg) : base()
    {
        CustomCode = 400004;
        CustomMessage = msg;
    }
}