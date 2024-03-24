using APIAeropuerto.Application.DTOs.Ship;
using APIAeropuerto.Application.UseCases.Ship;
using APIAeropuerto.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace APIAeropuerto.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ShipController: Controller
{
    private readonly IUseCase<ShipDTO, CreateShipDTO> _createShipUseCase;
    private readonly IUseCase<ShipDTO,UpdateShipDTO> _updateShipUseCase;
    private readonly IUseCase<string,DeleteShipDTO> _deleteShipUseCase;
    private readonly IUseCase<ShipDTO,GetOneShipDTO> _getOneShipUseCase;
    private readonly GetAllShipsUseCase _getAllShipsUseCase;

    public ShipController(
        IUseCase<ShipDTO, CreateShipDTO> createShipUseCase
        , IUseCase<ShipDTO, UpdateShipDTO> updateShipUseCase
        , IUseCase<string, DeleteShipDTO> deleteShipUseCase
        , IUseCase<ShipDTO, GetOneShipDTO> getOneShipUseCase
        , GetAllShipsUseCase getAllShipsUseCase)
    {
        _createShipUseCase = createShipUseCase;
        _updateShipUseCase = updateShipUseCase;
        _deleteShipUseCase = deleteShipUseCase;
        _getOneShipUseCase = getOneShipUseCase;
        _getAllShipsUseCase = getAllShipsUseCase;
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateShip([FromBody] CreateShipDTO dto, CancellationToken ct = default)
    {
        var result = await _createShipUseCase.Execute(dto, ct);
        return Ok(result);
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateShip([FromBody] UpdateShipDTO dto, CancellationToken ct = default)
    {
        var result = await _updateShipUseCase.Execute(dto, ct);
        return Ok(result);
    }
    
    [HttpDelete]
    public async Task<IActionResult> DeleteShip([FromBody] DeleteShipDTO dto, CancellationToken ct = default)
    {
        var result = await _deleteShipUseCase.Execute(dto, ct);
        return Ok(result);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllShips(CancellationToken ct = default)
    {
        var result = await _getAllShipsUseCase.Execute(ct);
        return Ok(result);
    }
    
    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetOneShip([FromRoute] Guid id, CancellationToken ct = default)
    {
        var dto = new GetOneShipDTO {Id = id};
        var result = await _getOneShipUseCase.Execute(dto, ct);
        return Ok(result);
    }
}