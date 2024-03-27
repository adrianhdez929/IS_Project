using APIAeropuerto.Application.Exceptions.BaseExceptions;

namespace APIAeropuerto.Application.Exceptions.BadRequest;

public class CreateUserBadRequestException : BaseBadRequestExceptions
{
    public CreateUserBadRequestException(string msg) : base()
    {
        CustomCode = 400001;
        CustomMessage = msg;
    }
}