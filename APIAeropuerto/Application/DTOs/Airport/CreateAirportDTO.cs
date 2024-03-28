using APIAeropuerto.Application.DTOs.Installations;

namespace APIAeropuerto.Application.DTOs.Airport;

public class CreateAirportDTO
{
    public string Name { get; set; }
    public string Address { get; set; }
    public string GeographicPosition { get; set; }
    public List<CreateInstallationsWithAirportDTO> Installations { get; set; } = new List<CreateInstallationsWithAirportDTO>();
}