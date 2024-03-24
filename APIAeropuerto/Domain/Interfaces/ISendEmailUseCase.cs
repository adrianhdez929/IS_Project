namespace APIAeropuerto.Domain.Interfaces;

public interface ISendEmailUseCase<MailDTO>
    where MailDTO : class
{
    void SendEmail(MailDTO mailDto);
}