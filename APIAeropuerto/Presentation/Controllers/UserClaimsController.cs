using APIAeropuerto.Application.DTOs.UserClaims;
using APIAeropuerto.Domain.Interfaces;
using APIAeropuerto.Domain.Shared;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APIAeropuerto.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserClaimsController : Controller
{
    private readonly IUseCase<IEnumerable<UserClaimsDTO>,GetAllUserClaimsDTO> _getAllUserClaimsUseCase;
    private readonly IUseCase<string,DeleteUserClaimsDTO> _deleteUserClaimsUseCase;
    public UserClaimsController(IUseCase<IEnumerable<UserClaimsDTO>,GetAllUserClaimsDTO> getAllUserClaimsUseCase, IUseCase<string,DeleteUserClaimsDTO> deleteUserClaimsUseCase)
    {
        _getAllUserClaimsUseCase = getAllUserClaimsUseCase;
        _deleteUserClaimsUseCase = deleteUserClaimsUseCase;
    }
    
    [HttpGet]
    [Route("{id}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = ClaimsStrings.ReadUserClaims)]
    public async Task<IActionResult> GetAll(Guid id, CancellationToken ct)
    {
        var result = await _getAllUserClaimsUseCase.Execute(new GetAllUserClaimsDTO() { Id = id });
        if (!result.Any()) return NotFound("User not has claims");
        return Ok(result);
    }
    
    [HttpDelete]
    [Route("{id}")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = ClaimsStrings.WriteUserClaims)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
    {
        var result = await _deleteUserClaimsUseCase.Execute(new DeleteUserClaimsDTO() { Id = id });
        return Ok(result);
    }
}