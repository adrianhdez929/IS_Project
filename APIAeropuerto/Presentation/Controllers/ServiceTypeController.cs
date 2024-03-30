using APIAeropuerto.Application.DTOs.ServiceType;
using APIAeropuerto.Application.UseCases.ServiceType;
using APIAeropuerto.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APIAeropuerto.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ServiceTypeController : Controller
{
    private readonly IUseCase<ServiceTypeDTO,CreateServiceTypeDTO> _createServiceTypeUseCase;
    private readonly IUseCase<ServiceTypeDTO,UpdateServiceTypeDTO> _updateServiceTypeUseCase;
    private readonly IUseCase<string,DeleteServiceTypeDTO> _deleteServiceTypeUseCase;
    private readonly IUseCase<ServiceTypeDTO,GetOneServiceTypeDTO> _getOneServiceTypeUseCase;
    private readonly GetAllServiceTypeUseCase _getAllServiceTypeUseCase;
    
    public ServiceTypeController(IUseCase<ServiceTypeDTO,CreateServiceTypeDTO> createServiceTypeUseCase, IUseCase<ServiceTypeDTO,UpdateServiceTypeDTO> updateServiceTypeUseCase, IUseCase<string,DeleteServiceTypeDTO> deleteServiceTypeUseCase, IUseCase<ServiceTypeDTO,GetOneServiceTypeDTO> getOneServiceTypeUseCase, GetAllServiceTypeUseCase getAllServiceTypeUseCase)
    {
        _createServiceTypeUseCase = createServiceTypeUseCase;
        _updateServiceTypeUseCase = updateServiceTypeUseCase;
        _deleteServiceTypeUseCase = deleteServiceTypeUseCase;
        _getOneServiceTypeUseCase = getOneServiceTypeUseCase;
        _getAllServiceTypeUseCase = getAllServiceTypeUseCase;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateServiceType([FromBody] CreateServiceTypeDTO dto)
    {
        var result = await _createServiceTypeUseCase.Execute(dto);
        return Ok(result);
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateServiceType([FromBody] UpdateServiceTypeDTO dto)
    {
        var result = await _updateServiceTypeUseCase.Execute(dto);
        return Ok(result);
    }
    
    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteServiceType(Guid id)
    {
        var result = await _deleteServiceTypeUseCase.Execute(new DeleteServiceTypeDTO(){Id = id});
        return Ok(result);
    }
    
    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetOneServiceType(Guid id)
    {
        var result = await _getOneServiceTypeUseCase.Execute(new GetOneServiceTypeDTO(){Id = id});
        return Ok(result);
    }
    
    [HttpGet]
    [Route("all")]
    public async Task<IActionResult> GetAllServiceType()
    {
        var result = await _getAllServiceTypeUseCase.Execute();
        return Ok(result);
    }
}