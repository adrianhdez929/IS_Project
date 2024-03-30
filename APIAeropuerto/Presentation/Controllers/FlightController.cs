using APIAeropuerto.Application.DTOs.Flight;
using APIAeropuerto.Application.UseCases.Flight;
using APIAeropuerto.Domain.Interfaces;
using APIAeropuerto.Domain.Shared;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APIAeropuerto.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FlightController : Controller
{
    private readonly IUseCase<FlightDTO,CreateFlightDTO> _createFlightUseCase;
    private readonly IUseCase<FlightDTO,UpdateFlightDTO> _updateFlightUseCase;
    private readonly IUseCase<FlightDTO,GetOneFlightDTO> _getOneFlightUseCase;
    private readonly IUseCase<string,DeleteFlightDTO> _deleteFlightUseCase;
    private readonly GetAllFlightsUseCase _getAllFlightsUseCase;

    
    public FlightController(IUseCase<FlightDTO,CreateFlightDTO> createFlightUseCase, IUseCase<FlightDTO,UpdateFlightDTO> updateFlightUseCase, IUseCase<FlightDTO,GetOneFlightDTO> getOneFlightUseCase, IUseCase<string,DeleteFlightDTO> deleteFlightUseCase, GetAllFlightsUseCase getAllFlightsUseCase)
    {
        _createFlightUseCase = createFlightUseCase;
        _updateFlightUseCase = updateFlightUseCase;
        _getOneFlightUseCase = getOneFlightUseCase;
        _deleteFlightUseCase = deleteFlightUseCase;
        _getAllFlightsUseCase = getAllFlightsUseCase;
    }
 
    [HttpPost]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = ClaimsStrings.WriteFlights)]
    public async Task<IActionResult> CreateFlight([FromBody] CreateFlightDTO dto, CancellationToken ct = default)
    {
        var result = await _createFlightUseCase.Execute(dto, ct);
        return Ok(result);
    }
    
    [HttpPut]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = ClaimsStrings.WriteFlights)]
    public async Task<IActionResult> UpdateFlight([FromBody] UpdateFlightDTO dto, CancellationToken ct = default)
    {
        var result = await _updateFlightUseCase.Execute(dto, ct);
        return Ok(result);
    }
    
    [HttpGet]
    [Route("{id}")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = ClaimsStrings.ReadFlights)]
    public async Task<IActionResult> GetOneFlight(Guid id, CancellationToken ct = default)
    {
        var result = await _getOneFlightUseCase.Execute(new GetOneFlightDTO(){Id = id}, ct);
        return Ok(result);
    }
    
    [HttpDelete]
    [Route("{id}")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = ClaimsStrings.WriteFlights)]
    public async Task<IActionResult> DeleteFlight(Guid id, CancellationToken ct = default)
    {
        var result = await _deleteFlightUseCase.Execute(new DeleteFlightDTO(){Id = id}, ct);
        return Ok(result);
    }
    
    [HttpGet]
    [Route("all")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = ClaimsStrings.ReadFlights)]
    public async Task<IActionResult> GetAllFlights(CancellationToken ct = default)
    {
        var result = await _getAllFlightsUseCase.Execute();
        return Ok(result);
    }
}