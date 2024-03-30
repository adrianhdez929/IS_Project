using APIAeropuerto.Application.DTOs.Airport;
using APIAeropuerto.Application.UseCases.Airport;
using APIAeropuerto.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APIAeropuerto.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AirportController : Controller
{
    private readonly IUseCase<AirportDTO, CreateAirportDTO> _createAirportUseCase;
    private readonly IUseCase<AirportDTO,UpdateAirportDTO> _updateAirportUseCase;
    private readonly IUseCase<string,DeleteAirportDTO> _deleteAirportUseCase;
    private readonly IUseCase<AirportDTO,GetOneAirportDTO> _getOneAirportUseCase;
    private readonly IUseCase<GetAirportInstDTO, GetOneAirportDTO> _getAirportInstUseCase;
    private readonly GetAllAirportUseCase _getAllAirportsUseCase;
    public AirportController(
        IUseCase<AirportDTO,CreateAirportDTO> createAirportUseCase,
        IUseCase<AirportDTO,UpdateAirportDTO> updateAirportUseCase,
        IUseCase<string,DeleteAirportDTO> deleteAirportUseCase,
        IUseCase<AirportDTO,GetOneAirportDTO> getOneAirportUseCase,
        IUseCase<GetAirportInstDTO,GetOneAirportDTO> getAirportInstUseCase,
        GetAllAirportUseCase getAllAirportsUseCase)
    {
        _createAirportUseCase = createAirportUseCase;
        _updateAirportUseCase = updateAirportUseCase;
        _deleteAirportUseCase = deleteAirportUseCase;
        _getOneAirportUseCase = getOneAirportUseCase;
        _getAirportInstUseCase = getAirportInstUseCase;
        _getAllAirportsUseCase = getAllAirportsUseCase;
    }
    
    [HttpPost]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = ClaimsStrings.WriteAirport)]
    public async Task<IActionResult> CreateAirport([FromBody] CreateAirportDTO dto)
    {
        var result = await _createAirportUseCase.Execute(dto);
        return Ok(result);
    }
    [HttpPut]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = ClaimsStrings.WriteAirport)]
    public async Task<IActionResult> UpdateAirport([FromBody] UpdateAirportDTO dto)
    {
        var result = await _updateAirportUseCase.Execute(dto);
        return Ok(result);
    }
    [HttpDelete]
    [Route("{id}")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = ClaimsStrings.WriteAirport)]
    public async Task<IActionResult> DeleteAirport(Guid id)
    {
        var result = await _deleteAirportUseCase.Execute(new DeleteAirportDTO(){Id = id});
        return Ok(result);
    }
    [HttpGet]
    [Route("all")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = ClaimsStrings.ReadAirport)]
    public async Task<IActionResult> GetAllAirports()
    {
        var result = await _getAllAirportsUseCase.Execute();
        return Ok(result);
    }
    [HttpGet]
    [Route("{id}")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = ClaimsStrings.ReadAirport)]
    public async Task<IActionResult> GetAirportById(Guid id)
    {
        var result = await _getOneAirportUseCase.Execute(new GetOneAirportDTO(){Id = id});
        return Ok(result);
    }

    [HttpGet]
    [Route("installations/{id}")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = ClaimsStrings.ReadAirport)]
    public async Task<IActionResult> GetAirportInstallations(Guid id)
    {
        var result = await _getAirportInstUseCase.Execute(new GetOneAirportDTO() { Id = id });
        return Ok(result);
    }
}