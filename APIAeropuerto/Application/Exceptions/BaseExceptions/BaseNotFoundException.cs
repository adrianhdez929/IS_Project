using System.Net;

namespace APIAeropuerto.Application.Exceptions.BaseExceptions;

public class BaseNotFoundException : CustomBaseException
{
    public BaseNotFoundException() : base()
    {
        HttpCode = (int)HttpStatusCode.NotFound;
    }
}