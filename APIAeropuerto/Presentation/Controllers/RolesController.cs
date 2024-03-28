using APIAeropuerto.Application.DTOs.Roles;
using APIAeropuerto.Application.UseCases.Roles;
using APIAeropuerto.Domain.Interfaces;
using APIAeropuerto.Domain.Shared;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APIAeropuerto.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RolesController : Controller
{
    private readonly IUseCase<RoleDTO,CreateRoleDTO> _createRoleUseCase;
    private readonly IUseCase<string,DeleteRoleDTO> _deleteRoleUseCase;
    private readonly IUseCase<RoleDTO,GetOneRoleDTO> _getOneRoleUseCase;
    private readonly IUseCase<RoleDTO,UpdateRoleDTO> _updateRoleUseCase;
    private readonly GetAllRolesUseCase _getAllRolesUseCase;
    
    public RolesController(
        IUseCase<RoleDTO,CreateRoleDTO> createRoleUseCase,
        IUseCase<string,DeleteRoleDTO> deleteRoleUseCase,
        IUseCase<RoleDTO,GetOneRoleDTO> getOneRoleUseCase,
        IUseCase<RoleDTO,UpdateRoleDTO> updateRoleUseCase,
        GetAllRolesUseCase getAllRolesUseCase)
    {
        _createRoleUseCase = createRoleUseCase;
        _deleteRoleUseCase = deleteRoleUseCase;
        _getOneRoleUseCase = getOneRoleUseCase;
        _updateRoleUseCase = updateRoleUseCase;
        _getAllRolesUseCase = getAllRolesUseCase;
    }
    
    [HttpGet]
    [Route("all")]
    // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,Policy = ClaimsStrings.ReadRole)]
    public async Task<IActionResult> GetAll(CancellationToken ct)
    {
        var result = await _getAllRolesUseCase.Execute();
        if (!result.Any()) return NotFound("No roles found");
        return Ok(result);
    }
    
    [HttpGet]
    [Route("{id}")]
    // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,Policy = ClaimsStrings.ReadRole)]
    public async Task<IActionResult> GetOne(Guid id, CancellationToken ct)
    {
        var result = await _getOneRoleUseCase.Execute(new GetOneRoleDTO() { Id = id });
        if (result == null) return NotFound("Role not found");
        return Ok(result);
    }
    
    [HttpPost]
    // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,Policy = ClaimsStrings.WriteRole)]
    public async Task<IActionResult> Create([FromBody] CreateRoleDTO dto, CancellationToken ct)
    {
        var result = await _createRoleUseCase.Execute(dto);
        return Ok(result);
    }
    
    [HttpPut]
    // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,Policy = ClaimsStrings.WriteRole)]
    public async Task<IActionResult> Update([FromBody] UpdateRoleDTO dto, CancellationToken ct)
    {
        var result = await _updateRoleUseCase.Execute(dto);
        return Ok(result);
    }
    
    [HttpDelete]
    [Route("{id}")]
    // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,Policy = ClaimsStrings.WriteRole)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken ct)
    {
        var result = await _deleteRoleUseCase.Execute(new DeleteRoleDTO() { Id = id });
        return Ok(result);
    }
}