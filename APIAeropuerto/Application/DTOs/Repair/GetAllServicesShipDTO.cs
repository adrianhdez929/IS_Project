using APIAeropuerto.Application.DTOs.Services;

namespace APIAeropuerto.Application.DTOs.Repair;

public class GetAllServicesShipDTO
{
    public Guid IdShip { get; set; }
    public IEnumerable<GetAllServicesDTO> Services { get; set; }
}