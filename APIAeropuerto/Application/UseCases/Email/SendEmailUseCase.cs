using System.Net.Mail;
using APIAeropuerto.Application.DTOs.Email;
using APIAeropuerto.Domain.Interfaces;

namespace APIAeropuerto.Application.UseCases.Email;

public class SendEmailUseCase : ISendEmailUseCase<EmailDTO>
{
    private readonly IConfiguration _configuration;
    private readonly SmtpClient _client;

    public SendEmailUseCase(IConfiguration configuration, SmtpClient client)
    {
        _configuration = configuration;
        _client = client;
    }
    public async void SendEmail(EmailDTO mailDto)
    {
        var message = new MailMessage(_configuration["Smtp:Username"]!, mailDto.RecipientEmail)
        {
            Subject = mailDto.Subject,
            Body = mailDto.Body
        };
        await _client.SendMailAsync(message);
    }
}