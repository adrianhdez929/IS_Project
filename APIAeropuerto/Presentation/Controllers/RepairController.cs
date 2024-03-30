using APIAeropuerto.Application.DTOs.Repair;
using APIAeropuerto.Application.UseCases.Repair;
using APIAeropuerto.Domain.Interfaces;
using APIAeropuerto.Domain.Shared;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APIAeropuerto.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RepairController : Controller
{
    private readonly IUseCase<RepairDTO, CreateRepairDTO> _createRepairUseCase;
    private readonly IUseCase<RepairDTO, UpdateRepairDTO> _updateRepairUseCase;
    private readonly IUseCase<GetAllRepairsShipDTO, GetAllRepairsShipDTO> _getAllRepairsShipUseCase;
    private readonly IUseCase<GetAllShipsRepairDTO, GetAllShipsRepairDTO> _getAllShipsRepairUseCase;
    private readonly IUseCase<string, DeleteRepairDTO> _deleteRepairUseCase;
    private readonly IUseCase<RepairDTO, GetOneRepairDTO> _getOneRepairUseCase;
    private readonly IUseCase<GetAllServicesShipDTO,GetAllServicesShipDTO> _getAllServicesShipUseCase;
    private readonly GetAllRepairUseCase _getAllRepairUseCase;

    public RepairController(IUseCase<RepairDTO, CreateRepairDTO> createRepairUseCase
        , IUseCase<RepairDTO, UpdateRepairDTO> updateRepairUseCase
        , IUseCase<GetAllRepairsShipDTO, GetAllRepairsShipDTO> getAllRepairsShipUseCase
        , IUseCase<GetAllShipsRepairDTO, GetAllShipsRepairDTO> getAllShipsRepairUseCase
        , IUseCase<string, DeleteRepairDTO> deleteRepairUseCase
        , IUseCase<RepairDTO, GetOneRepairDTO> getOneRepairUseCase
        , IUseCase<GetAllServicesShipDTO,GetAllServicesShipDTO> getAllServicesShipUseCase
        , GetAllRepairUseCase getAllRepairUseCase)
    {
        _createRepairUseCase = createRepairUseCase;
        _updateRepairUseCase = updateRepairUseCase;
        _getAllRepairsShipUseCase = getAllRepairsShipUseCase;
        _getAllShipsRepairUseCase = getAllShipsRepairUseCase;
        _deleteRepairUseCase = deleteRepairUseCase;
        _getOneRepairUseCase = getOneRepairUseCase;
        _getAllServicesShipUseCase = getAllServicesShipUseCase;
        _getAllRepairUseCase = getAllRepairUseCase;
    }

    [HttpPost]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = ClaimsStrings.WriteRepairs)]
    public async Task<IActionResult> Create([FromBody] CreateRepairDTO dto, CancellationToken ct = default)
    {
        var result = await _createRepairUseCase.Execute(dto, ct);
        return Ok(result);
    }
    
    [HttpPut]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = ClaimsStrings.WriteRepairs)]
    public async Task<IActionResult> Update([FromBody] UpdateRepairDTO dto, CancellationToken ct = default)
    {
        var result = await _updateRepairUseCase.Execute(dto, ct);
        return Ok(result);
    }
    
    [HttpGet]
    [Route("all")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = ClaimsStrings.ReadRepairs)]
    public async Task<IActionResult> GetAll(CancellationToken ct = default)
    {
        var result = await _getAllRepairUseCase.Execute(ct);
        return Ok(result);
    }
    
    [HttpGet]
    [Route("{id}")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = ClaimsStrings.ReadRepairs)]
    public async Task<IActionResult> GetOne(Guid id, CancellationToken ct = default)
    {
        var dto = new GetOneRepairDTO { Id = id };
        var result = await _getOneRepairUseCase.Execute(dto, ct);
        return Ok(result);
    }
    
    [HttpGet]
    [Route("repairs/{idShip}")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = ClaimsStrings.ReadRepairs)]
    public async Task<IActionResult> GetAllRepairsShip(Guid idShip, CancellationToken ct = default)
    {
        var dto = new GetAllRepairsShipDTO { IdShip = idShip };
        var result = await _getAllRepairsShipUseCase.Execute(dto, ct);
        return Ok(result);
    }
    
    [HttpGet]
    [Route("ships/{idRepair}")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = ClaimsStrings.ReadRepairs)]
    public async Task<IActionResult> GetAllShipsRepair(Guid idRepair, CancellationToken ct = default)
    {
        var dto = new GetAllShipsRepairDTO { IdRepair = idRepair };
        var result = await _getAllShipsRepairUseCase.Execute(dto, ct);
        return Ok(result);
    }
    
    [HttpDelete]
    [Route("{id}")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = ClaimsStrings.WriteRepairs)]
    public async Task<IActionResult> Delete(Guid id, CancellationToken ct = default)
    {
        var dto = new DeleteRepairDTO { Id = id };
        var result = await _deleteRepairUseCase.Execute(dto, ct);
        return Ok(result);
    }
    
    [HttpGet]
    [Route("services/{idShip}")]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Policy = ClaimsStrings.ReadRepairs)]
    public async Task<IActionResult> GetAllServicesShip(Guid idShip, CancellationToken ct = default)
    {
        var dto = new GetAllServicesShipDTO { IdShip = idShip };
        var result = await _getAllServicesShipUseCase.Execute(dto, ct);
        return Ok(result);
    }
}