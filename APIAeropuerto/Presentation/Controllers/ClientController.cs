using APIAeropuerto.Application.DTOs.Client;
using APIAeropuerto.Application.UseCases.Client;
using APIAeropuerto.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APIAeropuerto.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientController : Controller
{
    private readonly IUseCase<ClientDTO,CreateClientDTO> _createClientUseCase;
    private readonly IUseCase<ClientDTO,UpdateClientDTO> _updateClientUseCase;
    private readonly IUseCase<ClientDTO,GetOneClientDTO> _getOneClientUseCase;
    private readonly IUseCase<string,DeleteClientDTO> _deleteClientUseCase;
    private readonly IUseCase<GetlAllServicesClientDTO,GetOneClientDTO> _getAllServicesClientUseCase;
    private readonly IUseCase<string,AddServiceDTO> _addServiceUseCase;
    private readonly GetAllClientsUseCase _getAllClientsUseCase;
    
    public ClientController(IUseCase<ClientDTO,
        CreateClientDTO> createClientUseCase,
        IUseCase<ClientDTO,UpdateClientDTO> updateClientUseCase,
        IUseCase<ClientDTO,GetOneClientDTO> getOneClientUseCase,
        IUseCase<string,DeleteClientDTO> deleteClientUseCase, 
        IUseCase<GetlAllServicesClientDTO,GetOneClientDTO> getAllServicesClientUseCase,
        IUseCase<string,AddServiceDTO> addServiceUseCase,
        GetAllClientsUseCase getAllClientsUseCase)
    {
        _createClientUseCase = createClientUseCase;
        _updateClientUseCase = updateClientUseCase;
        _getOneClientUseCase = getOneClientUseCase;
        _deleteClientUseCase = deleteClientUseCase;
        _getAllServicesClientUseCase = getAllServicesClientUseCase;
        _addServiceUseCase = addServiceUseCase;
        _getAllClientsUseCase = getAllClientsUseCase;
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateClientDTO dto, CancellationToken ct = default)
    {
        var result = await _createClientUseCase.Execute(dto,ct);
        return Ok(result);
    }
    
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateClientDTO dto, CancellationToken ct = default)
    {
        var result = await _updateClientUseCase.Execute(dto,ct);
        return Ok(result);
    }
    
    [HttpGet]
    [Route("all")]
    public async Task<IActionResult> GetAll(CancellationToken ct = default)
    {
        var result = await _getAllClientsUseCase.Execute();
        return Ok(result);
    }
    
    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetOne(Guid id, CancellationToken ct = default)
    {
        var result = await _getOneClientUseCase.Execute(new GetOneClientDTO(){Id = id},ct);
        return Ok(result);
    }
    
    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken ct = default)
    {
        var result = await _deleteClientUseCase.Execute(new DeleteClientDTO(){Id = id},ct);
        return Ok(result);
    }
    
    [HttpGet]
    [Route("{id}/services")]
    public async Task<IActionResult> GetServices(Guid id, CancellationToken ct = default)
    {
        var result = await _getAllServicesClientUseCase.Execute(new GetOneClientDTO(){Id = id},ct);
        return Ok(result);
    }
    
    [HttpPost]
    [Route("add/services")]
    public async Task<IActionResult> AddService([FromBody]AddServiceDTO addServiceDto, CancellationToken ct = default)
    {
        var result = await _addServiceUseCase.Execute(addServiceDto,ct);
        return Ok(result);
    }
}