using APIAeropuerto.Domain.Enums;

namespace APIAeropuerto.Application.DTOs.Installations;

public class InstallationDTO
{
    public string? Name { get; set; }
    public string Description { get; set; }
    public string Location { get; set; }
    public string Type { get; set; }
    public Guid IdAirport { get; set; }
    public string NameAirport { get; set; }
}