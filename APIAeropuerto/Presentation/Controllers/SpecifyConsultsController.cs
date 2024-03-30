using APIAeropuerto.Application.DTOs.SpecifyConsults;
using APIAeropuerto.Application.UseCases.SpecifyConsults;
using Microsoft.AspNetCore.Mvc;

namespace APIAeropuerto.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SpecifyConsultsController : Controller
{
    private readonly GetAirportWithRepairServicesUseCase _getAirportWithRepairServicesUseCase;
    private readonly GetAmountRepairAirportUseCase _getAmountRepairAirportUseCase;
    private readonly GetClientAirportJMUseCase _getClientAirportJMUseCase;
    private readonly GetAirportWithLessShipUseCase _getAirportWithLessShipUseCase;
    private readonly GetAvgServicesPriceJMUseCase _getAvgServicesPriceJMUseCase;
    private readonly DeleteInneficientServicesUseCase _deleteInneficientServicesUseCase;
    
    public SpecifyConsultsController(GetAirportWithRepairServicesUseCase getAirportWithRepairServicesUseCase
    , GetAmountRepairAirportUseCase getAmountRepairAirportUseCase
    , GetClientAirportJMUseCase getClientAirportJMUseCase
    , GetAirportWithLessShipUseCase getAirportWithLessShipUseCase
    , GetAvgServicesPriceJMUseCase getAvgServicesPriceJMUseCase
    , DeleteInneficientServicesUseCase deleteInneficientServicesUseCase)
    {
        _getAirportWithRepairServicesUseCase = getAirportWithRepairServicesUseCase;
        _getAmountRepairAirportUseCase = getAmountRepairAirportUseCase;
        _getClientAirportJMUseCase = getClientAirportJMUseCase;
        _getAirportWithLessShipUseCase = getAirportWithLessShipUseCase;
        _getAvgServicesPriceJMUseCase = getAvgServicesPriceJMUseCase;
        _deleteInneficientServicesUseCase = deleteInneficientServicesUseCase;
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
    
    [HttpGet]
    [Route("GetClientAirportJM")]
    public async Task<IActionResult> GetClientAirportJM()
    {
        var result = await _getClientAirportJMUseCase.Execute();
        return Ok(result);
    }
    
    [HttpGet]
    [Route("GetAirportWithLessShip")]
    public async Task<IActionResult> GetAirportWithLessShip()
    {
        var result = await _getAirportWithLessShipUseCase.Execute();
        return Ok(result);
    }
    
    [HttpDelete]
    [Route("DeleteInneficientServices/{id}")]
    public async Task<IActionResult> DeleteInneficientServices(Guid id)
    {
        var result = await _deleteInneficientServicesUseCase.Execute(new DeleteInneficientServicesDTO(){Id = id});
        return Ok(result);
    }
    
    [HttpGet]
    [Route("GetAvgServicesPriceJM")]
    public async Task<IActionResult> GetAvgServicesPriceJM()
    {
        var result = await _getAvgServicesPriceJMUseCase.Execute();
        return Ok(result);
    }
}