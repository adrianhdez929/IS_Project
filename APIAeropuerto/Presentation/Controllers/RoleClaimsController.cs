using APIAeropuerto.Application.DTOs.RoleClaims;
using APIAeropuerto.Domain.Interfaces;
using APIAeropuerto.Domain.Shared;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APIAeropuerto.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RoleClaimsController : Controller
{
    private readonly IUseCase<IEnumerable<RoleClaimsDTO>,GetAllRoleClaimsDTO> _getAllRoleClaimsUseCase;
    private readonly IUseCase<string,DeleteRoleClaimsDTO> _deleteRoleClaimsUseCase;
    public RoleClaimsController(IUseCase<IEnumerable<RoleClaimsDTO>,GetAllRoleClaimsDTO> getAllRoleClaimsUseCase, IUseCase<string,DeleteRoleClaimsDTO> deleteRoleClaimsUseCase)
    {
        _getAllRoleClaimsUseCase = getAllRoleClaimsUseCase;
        _deleteRoleClaimsUseCase = deleteRoleClaimsUseCase;
    }

    [HttpGet]
    [Route("{id}")]
    // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = ClaimsStrings.ReadRoleClaims)]
    public async Task<IActionResult> GetAll(Guid id, CancellationToken ct)
    {
        var result = await _getAllRoleClaimsUseCase.Execute(new GetAllRoleClaimsDTO() { Id = id });
        if (!result.Any()) return NotFound("Role not has claims");
        return Ok(result);
    }
    
    [HttpDelete]
    [Route("{id}")]
    // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = ClaimsStrings.WriteRoleClaims)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
    {
        var result = await _deleteRoleClaimsUseCase.Execute(new DeleteRoleClaimsDTO() { Id = id });
        return Ok(result);
    }
}