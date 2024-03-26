using System.Net;

namespace APIAeropuerto.Application.Exceptions.BaseExceptions;

public class BaseBadRequestExceptions : CustomBaseException
{
    public BaseBadRequestExceptions() : base()
    {
        HttpCode = (int)HttpStatusCode.BadRequest;
    }
}