using System.Web;
using APIAeropuerto.Application.DTOs.Auth;
using APIAeropuerto.Application.DTOs.Email;
using APIAeropuerto.Domain.Interfaces;
using APIAeropuerto.Persistence.Entities;
using Microsoft.AspNetCore.Identity;

namespace APIAeropuerto.Application.UseCases.Auth;

public class ForgetPasswordUseCase : IUseCase<string,ForgetPasswordDTO>
{
    private readonly UserManager<UserPersistence> _userManager;
    private readonly ISendEmailUseCase<EmailDTO> _sendEmailUseCase;
    public ForgetPasswordUseCase(UserManager<UserPersistence> userManager, ISendEmailUseCase<EmailDTO> sendEmailUseCase)
    {
        _userManager = userManager;
        _sendEmailUseCase = sendEmailUseCase;
    }
    public async Task<string> Execute(ForgetPasswordDTO dto, CancellationToken ct = default)
    {
        var user = await _userManager.FindByEmailAsync(dto.Email);
        if(user is null) throw new Exception("User not found");
        var token = await _userManager.GeneratePasswordResetTokenAsync(user);
        var callbackUrl = $"https://localhost:7016/api/auth/resetpassword/email={dto.Email}&token={HttpUtility.UrlEncode(token)}";
        var body =  $"Por favor, resetea tu contraseña haciendo clic <a href='{callbackUrl}'>aquí</a>.";
        _sendEmailUseCase.SendEmail(new EmailDTO(){RecipientEmail = dto.Email, Subject = "Resetear contraseña", Body = body});
        return "Email sent successfully";
    }
}