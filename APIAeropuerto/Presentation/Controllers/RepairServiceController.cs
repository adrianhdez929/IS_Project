using APIAeropuerto.Application.DTOs.Services;
using APIAeropuerto.Application.UseCases.RepairService;
using APIAeropuerto.Domain.Interfaces;
using APIAeropuerto.Domain.Shared;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APIAeropuerto.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RepairServiceController : Controller
{
    private readonly IUseCase<ServiceDTO, CreateRepairServiceDTO> _useCase;
    private readonly GetAllRepairServicesUseCase _getAllRepairServicesUseCase;
    public RepairServiceController(IUseCase<ServiceDTO, CreateRepairServiceDTO> useCase
    , GetAllRepairServicesUseCase getAllRepairServicesUseCase)
    {
        _useCase = useCase;
        _getAllRepairServicesUseCase = getAllRepairServicesUseCase;
    }

    [HttpPost]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = ClaimsStrings.WriteRepairServices)]
    public async Task<IActionResult> CreateRepairService([FromBody] CreateRepairServiceDTO dto)
    {
        var result = await _useCase.Execute(dto);
        return Ok(result);
    }
    
    [HttpGet]
    [Route("all")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = ClaimsStrings.ReadRepairServices)]
    public async Task<IActionResult> GetAllRepairServices()
    {
        var result = await _getAllRepairServicesUseCase.Execute();
        return Ok(result);
    }
}