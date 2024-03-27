using APIAeropuerto.Application.Exceptions.BaseExceptions;

namespace APIAeropuerto.Application.Exceptions.BadRequest;

public class PasswordBadRequestException : BaseBadRequestExceptions
{
    public PasswordBadRequestException(string msg) : base()
    {
        CustomCode = 400002;
        CustomMessage = msg;
    }
}