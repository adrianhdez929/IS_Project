namespace APIAeropuerto.Application.Exceptions.BaseExceptions;

public class CustomBaseException : Exception
{
    public int HttpCode { get; set; }
    public int CustomCode { get; set; }
    public string CustomMessage { get; set; }
    
    public CustomBaseException() : base()
    {
    }
}