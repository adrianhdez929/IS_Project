namespace APIAeropuerto.Application.DTOs.Repair;

public class GetAllRepairsShipDTO
{
    public Guid IdShip { get; set; }
    public IEnumerable<GetAllRepairDTO> Repairs { get; set; }
}