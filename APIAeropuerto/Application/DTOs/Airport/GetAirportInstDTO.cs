using APIAeropuerto.Application.DTOs.Installations;

namespace APIAeropuerto.Application.DTOs.Airport;

public class GetAirportInstDTO
{
    public List<InstallationDTO> Installations { get; set; }
}