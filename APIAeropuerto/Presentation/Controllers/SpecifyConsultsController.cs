using APIAeropuerto.Application.UseCases.SpecifyConsults;
using Microsoft.AspNetCore.Mvc;

namespace APIAeropuerto.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SpecifyConsultsController : Controller
{
    private readonly GetAirportWithRepairServicesUseCase _getAirportWithRepairServicesUseCase;
    private readonly GetAmountRepairAirportUseCase _getAmountRepairAirportUseCase;
    
    public SpecifyConsultsController(GetAirportWithRepairServicesUseCase getAirportWithRepairServicesUseCase
    , GetAmountRepairAirportUseCase getAmountRepairAirportUseCase)
    {
        _getAirportWithRepairServicesUseCase = getAirportWithRepairServicesUseCase;
        _getAmountRepairAirportUseCase = getAmountRepairAirportUseCase;
    }

    [HttpGet]
    [Route("GetAirportWithRepairServices")]
    public async Task<IActionResult> GetAirportWithRepairServices()
    {
        var result = await _getAirportWithRepairServicesUseCase.Execute();
        return Ok(result);
    }
    
    [HttpGet]
    [Route("GetAmountRepairAirport")]
    public async Task<IActionResult> GetAmountRepairAirport()
    {
        var result = await _getAmountRepairAirportUseCase.Execute();
        return Ok(result);
    }
}