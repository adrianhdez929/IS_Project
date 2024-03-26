using System.Net;

namespace APIAeropuerto.Application.Exceptions.BaseExceptions;

public class BaseForbbidenException : CustomBaseException
{
    public BaseForbbidenException() : base()
    {
        HttpCode = (int)HttpStatusCode.Forbidden;
    }
}