using APIAeropuerto.Application.DTOs.Services;
using APIAeropuerto.Application.UseCases.Services;
using APIAeropuerto.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APIAeropuerto.Presentation.Controllers;

[Route("api/[controller]")]
[Controller]
public class ServicesController : Controller
{
    private readonly IUseCase<ServiceDTO, CreateServiceDTO> _createServiceUseCase;
    private readonly IUseCase<string, DeleteServiceDTO> _deleteServiceUseCase;
    private readonly IUseCase<ServiceDTO, GetOneServiceDTO> _getOneServiceUseCase;
    private readonly IUseCase<ServiceDTO, UpdateServiceDTO> _updateServiceUseCase;
    private readonly IUseCase<GetAllClientsServiceDTO,GetOneServiceDTO> _getAllClientsServiceUseCase;
    private readonly GetAllServicesUseCase _getAllServicesUseCase;
    public ServicesController(
        IUseCase<ServiceDTO,CreateServiceDTO> createServiceUseCase,
        IUseCase<string,DeleteServiceDTO> deleteServiceUseCase,
        IUseCase<ServiceDTO,GetOneServiceDTO> getOneServiceUseCase,
        IUseCase<ServiceDTO,UpdateServiceDTO> updateServiceUseCase,
        IUseCase<GetAllClientsServiceDTO,GetOneServiceDTO> getAllClientsServiceUseCase,
        GetAllServicesUseCase getAllServicesUseCase)
    {
        _createServiceUseCase = createServiceUseCase;
        _deleteServiceUseCase = deleteServiceUseCase;
        _getOneServiceUseCase = getOneServiceUseCase;
        _updateServiceUseCase = updateServiceUseCase;
        _getAllClientsServiceUseCase = getAllClientsServiceUseCase;
        _getAllServicesUseCase = getAllServicesUseCase;
    }

    [HttpPost]
    public async Task<IActionResult> CreateService([FromBody] CreateServiceDTO dto)
    {
        var result = await _createServiceUseCase.Execute(dto);
        return Ok(result);
    }

    [HttpDelete]
    [Route("{code}")]
    public async Task<IActionResult> DeleteService(string code)
    {
        var result = await _deleteServiceUseCase.Execute(new DeleteServiceDTO() { Code = code });
        return Ok(result);
    }

    [HttpGet]
    [Route("all")]
    public async Task<IActionResult> GetAllServices()
    {
        var result = await _getAllServicesUseCase.Execute();
        return Ok(result);
    }

    [HttpGet]
    [Route("{code}")]
    public async Task<IActionResult> GetOneService(string code)
    {
        var result = await _getOneServiceUseCase.Execute(new GetOneServiceDTO() { Code = code });
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateService([FromBody] UpdateServiceDTO dto)
    {
        var result = await _updateServiceUseCase.Execute(dto);
        return Ok(result);
    }
    [HttpGet]
    [Route("{code}/clients")]
    public async Task<IActionResult> GetAllClientsService(string code)
    {
        var result = await _getAllClientsServiceUseCase.Execute(new GetOneServiceDTO() { Code = code });
        return Ok(result);
    }
}