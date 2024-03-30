using APIAeropuerto.Application.DTOs.InstallationType;
using APIAeropuerto.Domain.Enums;

namespace APIAeropuerto.Application.DTOs.Installations;

public class CreateInstallationsWithAirportDTO
{
    public string Name { get; set; }
    public string Description { get; set; }
    public Guid IdInstallationType { get; set; }
    public string Location { get; set; }
}