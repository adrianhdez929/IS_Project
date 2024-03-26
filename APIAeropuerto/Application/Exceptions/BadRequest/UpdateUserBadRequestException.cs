using APIAeropuerto.Application.Exceptions.BaseExceptions;

namespace APIAeropuerto.Application.Exceptions.BadRequest;

public class UpdateUserBadRequestException : BaseBadRequestExceptions
{
    public UpdateUserBadRequestException(string msg) : base()
    {
        CustomCode = 400002;
        CustomMessage = msg;
    }
}