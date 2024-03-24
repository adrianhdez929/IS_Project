using APIAeropuerto.Application.DTOs.Auth;
using APIAeropuerto.Application.DTOs.UserLogin;
using APIAeropuerto.Application.UseCases.Auth;
using APIAeropuerto.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APIAeropuerto.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : Controller
{
    public readonly IUseCase<UserLoginDTO, CredentialModelDTO> _loginUseCase;
    public readonly IUseCase<string,ForgetPasswordDTO> _forgetPasswordUseCase;
    public readonly IUseCase<string,ResetPasswordDTO> _resetPasswordUseCase;
    
    public AuthController(IUseCase<UserLoginDTO, CredentialModelDTO> loginUseCase
        , IUseCase<string,ForgetPasswordDTO> forgetPasswordUseCase
        , IUseCase<string,ResetPasswordDTO> resetPasswordUseCase)
    {
        _loginUseCase = loginUseCase;
        _forgetPasswordUseCase = forgetPasswordUseCase;
        _resetPasswordUseCase = resetPasswordUseCase;
    }
    
    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login([FromBody] CredentialModelDTO credential)
    {
        try
        {
            var result = await _loginUseCase.Execute(credential);
            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpPost]
    [Route("forgetpassword")]
    public async Task<IActionResult> ForgetPassword([FromBody] ForgetPasswordDTO dto)
    {
        try
        {
            var result = await _forgetPasswordUseCase.Execute(dto);
            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpPost]
    [Route("resetpassword")]
    public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDTO dto)
    {
        try
        {
            var result = await _resetPasswordUseCase.Execute(dto);
            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}