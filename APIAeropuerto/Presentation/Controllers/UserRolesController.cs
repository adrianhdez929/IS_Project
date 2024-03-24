using APIAeropuerto.Application.DTOs.UserRoles;
using APIAeropuerto.Domain.Interfaces;
using APIAeropuerto.Domain.Shared;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APIAeropuerto.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserRolesController : Controller
{
    private readonly IUseCase<IEnumerable<UserRolesDTO>, GetAllUserRolesDTO> _getAllUserRolesUseCase;
    private readonly IUseCase<string, DeleteUserRolesDTO> _deleteUserRolesUseCase;
    private readonly IUseCase<string, AddRolesToUserDTO> _addRolesToUserUseCase;
    public UserRolesController(
        IUseCase<IEnumerable<UserRolesDTO>,GetAllUserRolesDTO> getAllUserRolesUseCase
        ,IUseCase<string, DeleteUserRolesDTO> deleteUserRolesUseCase,
        IUseCase<string, AddRolesToUserDTO> addRolesToUserUseCase)
    {
        _getAllUserRolesUseCase = getAllUserRolesUseCase;
        _deleteUserRolesUseCase = deleteUserRolesUseCase;
        _addRolesToUserUseCase = addRolesToUserUseCase;
    }

    [HttpGet]
    [Route("{id}")]
    // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,Policy = ClaimsStrings.ReadUserRoles)]
    public async Task<IActionResult> GetAll(Guid id, CancellationToken ct)
    {
        var result = await _getAllUserRolesUseCase.Execute(new GetAllUserRolesDTO() { Id = id });
        if (!result.Any()) return NotFound("User not has roles");
        return Ok(result);
    }
    
    [HttpDelete]
    [Route("{id}")]
    // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,Policy = ClaimsStrings.WriteUserRoles)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
    {
        var result = await _deleteUserRolesUseCase.Execute(new DeleteUserRolesDTO() { Id = id });
        return Ok(result);
    }
    
    [HttpPost]
    [Route("add")]
    // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,Policy = ClaimsStrings.WriteUserRoles)]
    public async Task<IActionResult> Add([FromBody] AddRolesToUserDTO dto, CancellationToken ct)
    {
        var result = await _addRolesToUserUseCase.Execute(dto);
        return Ok(result);
    }
}