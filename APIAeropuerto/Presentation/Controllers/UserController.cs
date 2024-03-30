using APIAeropuerto.Application.DTOs.Users;
using APIAeropuerto.Application.UseCases.Users;
using APIAeropuerto.Domain.Interfaces;
using APIAeropuerto.Domain.Shared;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APIAeropuerto.Presentation.Controllers;

[Route("api/[controller]")]
[Controller]
public class UserController : Controller
{
    private readonly IUseCase<UsersDTO,CreateUserDTO> _createUserUseCase;
    private readonly IUseCase<string,DeleteUserDTO> _deleteUserUseCase;
    private readonly IUseCase<UsersDTO,GetOneUserDTO> _getOneUserUseCase;
    private readonly IUseCase<UsersDTO,UpdateUserDTO> _updateUserUseCase;
    private readonly GetAllUsersUseCase _getAllUsersUseCase;
    public UserController(IUseCase<UsersDTO,CreateUserDTO> createUserUseCase
        , IUseCase<string,DeleteUserDTO> deleteUserUseCase
        , IUseCase<UsersDTO,GetOneUserDTO> getOneUserUseCase
        , IUseCase<UsersDTO,UpdateUserDTO> updateUserUseCase
        , GetAllUsersUseCase getAllUsersUseCase)
    {
        _createUserUseCase = createUserUseCase;
        _deleteUserUseCase = deleteUserUseCase;
        _getOneUserUseCase = getOneUserUseCase;
        _updateUserUseCase = updateUserUseCase;
        _getAllUsersUseCase = getAllUsersUseCase;
    }
    [HttpPost]
    // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = ClaimsStrings.WriteUser)]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserDTO dto, CancellationToken ct = default)
    {
        try
        {
            var result = await _createUserUseCase.Execute(dto, ct);
            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpDelete]
    [Route("{id}")]
    // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = ClaimsStrings.WriteUser)]
    public async Task<IActionResult> DeleteUser(Guid id, CancellationToken ct)
    {
        var result = await _deleteUserUseCase.Execute(new DeleteUserDTO() { Id = id });
        return Ok(result);
    }
    
    [HttpGet]
    [Route("{id}")]
    // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = ClaimsStrings.ReadUser)]
    public async Task<IActionResult> GetOneUser(Guid id, CancellationToken ct)
    {
        var result = await _getOneUserUseCase.Execute(new GetOneUserDTO() { Id = id });
        if (result is null) return NotFound("User not found");
        return Ok(result);
    }
    
    [HttpPut]
    // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = ClaimsStrings.WriteUser)]
    public async Task<IActionResult> UpdateUser([FromBody] UpdateUserDTO dto, CancellationToken ct = default)
    {
        try
        {
            var result = await _updateUserUseCase.Execute(dto, ct);
            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpGet]
    [Route("all")]
    // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = ClaimsStrings.ReadUser)]
    public async Task<IActionResult> GetAll(CancellationToken ct)
    {
        var result = await _getAllUsersUseCase.Execute();
        if (!result.Any()) return NotFound("No users found");
        return Ok(result);
    }
}