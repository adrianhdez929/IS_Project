using APIAeropuerto.Application.Exceptions.BaseExceptions;
using Microsoft.Extensions.Localization;

namespace APIAeropuerto.Application.Exceptions.BadRequest;

public class EmailNotValidBadRequestException : BaseBadRequestExceptions
{
    public EmailNotValidBadRequestException(string msg) : base()
    {
       CustomCode = 400018;
       CustomMessage = msg;
    }
}