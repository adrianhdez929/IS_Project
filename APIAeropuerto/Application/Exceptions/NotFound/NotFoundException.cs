using APIAeropuerto.Application.Exceptions.BaseExceptions;

namespace APIAeropuerto.Application.Exceptions.NotFound;

public class NotFoundException : BaseNotFoundException
{
    public NotFoundException(string msg) : base()
    {
        CustomCode = 404000;
        CustomMessage = msg;
    }
}