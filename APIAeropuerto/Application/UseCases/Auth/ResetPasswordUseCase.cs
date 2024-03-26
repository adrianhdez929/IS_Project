using System.Web;
using APIAeropuerto.Application.DTOs.Auth;
using APIAeropuerto.Application.Exceptions.NotFound;
using APIAeropuerto.Domain.Interfaces;
using APIAeropuerto.Persistence.Entities;
using Microsoft.AspNetCore.Identity;

namespace APIAeropuerto.Application.UseCases.Auth;

public class ResetPasswordUseCase : IUseCase<string,ResetPasswordDTO>
{
    private readonly UserManager<UserPersistence> _userManager;
    public ResetPasswordUseCase(UserManager<UserPersistence> userManager)
    {
        _userManager = userManager;
    }
    public async Task<string> Execute(ResetPasswordDTO dto, CancellationToken ct = default)
    {
        if(dto.Password != dto.ConfirmPassword) throw new Exception("Passwords do not match");
        var user = await _userManager.FindByEmailAsync(dto.Email);
        if(user is null) throw new NotFoundException("User not found");
        var tokenDecoded = HttpUtility.UrlDecode(dto.Token);
        var result = await _userManager.ResetPasswordAsync(user, tokenDecoded, dto.Password);
        if(!result.Succeeded) throw new Exception(result.Errors.First().Description);
        return "Password reset successfully";
    }
}