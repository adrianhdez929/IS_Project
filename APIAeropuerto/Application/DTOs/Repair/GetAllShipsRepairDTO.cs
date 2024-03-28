using APIAeropuerto.Application.DTOs.Ship;

namespace APIAeropuerto.Application.DTOs.Repair;

public class GetAllShipsRepairDTO
{
    public Guid IdRepair { get; set; }
    public IEnumerable<ShipDTO> Ships { get; set; }
}