using APIAeropuerto.Application.Exceptions.BaseExceptions;

namespace APIAeropuerto.Application.Exceptions.BadRequest;

public class CreateRepairBadRequestException : BaseBadRequestExceptions
{
    public CreateRepairBadRequestException(string msg) : base()
    {
        CustomCode = 400001;
        CustomMessage = msg;
    }
}