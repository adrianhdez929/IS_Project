using APIAeropuerto.Application.Exceptions.BaseExceptions;

namespace APIAeropuerto.Application.Exceptions.BadRequest;

public class InvalidClaimBadRequestException : BaseBadRequestExceptions
{
    public InvalidClaimBadRequestException(string msg) : base()
    {
        CustomCode = 400002;
        CustomMessage = msg;
    }
}