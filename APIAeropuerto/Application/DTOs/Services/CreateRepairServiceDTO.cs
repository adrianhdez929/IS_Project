using APIAeropuerto.Application.DTOs.Services;

namespace APIAeropuerto.Application.DTOs.Services;

public class CreateRepairServiceDTO
{ 
    public string Code { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public Guid InstallationId { get; set; }
    public IEnumerable<Guid> RepairService { get; set; } = new List<Guid>();
}