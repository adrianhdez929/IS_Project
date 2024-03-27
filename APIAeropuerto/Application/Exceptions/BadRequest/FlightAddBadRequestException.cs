using APIAeropuerto.Application.Exceptions.BaseExceptions;

namespace APIAeropuerto.Application.Exceptions.BadRequest;

public class FlightAddBadRequestException : BaseBadRequestExceptions
{
    public FlightAddBadRequestException(string msg) : base()
    {
        CustomCode = 400003;
        CustomMessage = msg;
    }
}