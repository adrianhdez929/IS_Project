using APIAeropuerto.Application.DTOs.ClientType;
using APIAeropuerto.Application.UseCases.ClientType;
using APIAeropuerto.Domain.Interfaces;
using APIAeropuerto.Domain.Shared;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APIAeropuerto.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientTypeController : Controller
{
    private readonly IUseCase<ClientTypeDTO,CreateClientTypeDTO> _createClientTypeUseCase;
    private readonly IUseCase<ClientTypeDTO,GetOneClientTypeDTO> _getOneClientTypeUseCase;
    private readonly IUseCase<ClientTypeDTO,UpdateClientTypeDTO> _updateClientTypeUseCase;
    private readonly IUseCase<string,DeleteClientTypeDTO> _deleteClientTypeUseCase;
    private readonly GetAllClientTypeUseCase _getAllClientTypeUseCase;
    
    public ClientTypeController(IUseCase<ClientTypeDTO,CreateClientTypeDTO> createClientTypeUseCase, IUseCase<ClientTypeDTO,GetOneClientTypeDTO> getOneClientTypeUseCase, IUseCase<ClientTypeDTO,UpdateClientTypeDTO> updateClientTypeUseCase, IUseCase<string,DeleteClientTypeDTO> deleteClientTypeUseCase, GetAllClientTypeUseCase getAllClientTypeDTO)
    {
        _createClientTypeUseCase = createClientTypeUseCase;
        _getOneClientTypeUseCase = getOneClientTypeUseCase;
        _updateClientTypeUseCase = updateClientTypeUseCase;
        _deleteClientTypeUseCase = deleteClientTypeUseCase;
        _getAllClientTypeUseCase = getAllClientTypeDTO;
    }
    
    [HttpPost]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = ClaimsStrings.WriteClientTypes)]
    public async Task<IActionResult> CreateClientType([FromBody] CreateClientTypeDTO dto)
    {
        var result = await _createClientTypeUseCase.Execute(dto);
        return Ok(result);
    }
    
    [HttpGet]
    [Route("{id}")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = ClaimsStrings.ReadClientTypes)]
    public async Task<IActionResult> GetOneClientType(Guid id)
    {
        var dto = new GetOneClientTypeDTO { Id = id };
        var result = await _getOneClientTypeUseCase.Execute(dto);
        return Ok(result);
    }
    
    [HttpPut]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = ClaimsStrings.WriteClientTypes)]
    public async Task<IActionResult> UpdateClientType([FromBody] UpdateClientTypeDTO dto)
    {
        var result = await _updateClientTypeUseCase.Execute(dto);
        return Ok(result);
    }
    
    [HttpDelete]
    [Route("{id}")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = ClaimsStrings.WriteClientTypes)]
    public async Task<IActionResult> DeleteClientType(Guid id)
    {
        var dto = new DeleteClientTypeDTO { Id = id };
        var result = await _deleteClientTypeUseCase.Execute(dto);
        return Ok(result);
    }
    
    [HttpGet]
    [Route("all")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = ClaimsStrings.ReadClientTypes)]
    public async Task<IActionResult> GetAllClientType()
    {
        var result = await _getAllClientTypeUseCase.Execute();
        return Ok(result);
    }
}