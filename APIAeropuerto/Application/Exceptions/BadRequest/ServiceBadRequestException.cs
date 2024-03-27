using APIAeropuerto.Application.Exceptions.BaseExceptions;

namespace APIAeropuerto.Application.Exceptions.BadRequest;

public class ServiceBadRequestException : BaseBadRequestExceptions
{
    public ServiceBadRequestException(string msg) : base()
    {
        CustomCode = 400003;
        CustomMessage = msg;
    }
}