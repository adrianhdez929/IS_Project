using System.Net;

namespace APIAeropuerto.Application.Exceptions.BaseExceptions;

public class BaseUnauthorizedException : CustomBaseException
{
    public BaseUnauthorizedException() : base()
    {
        HttpCode = (int)HttpStatusCode.Unauthorized;
    }
}