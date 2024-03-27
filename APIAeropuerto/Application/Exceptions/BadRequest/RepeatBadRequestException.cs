using APIAeropuerto.Application.Exceptions.BaseExceptions;

namespace APIAeropuerto.Application.Exceptions.BadRequest;

public class RepeatBadRequestException : BaseBadRequestExceptions
{
    public RepeatBadRequestException(string msg) : base()
    {
        CustomCode = 400001;
        CustomMessage = msg;
    }
}