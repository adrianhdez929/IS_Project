using APIAeropuerto.Application.DTOs.Installations;

namespace APIAeropuerto.Application.DTOs.Airport;

public class GetAirportInstDTO
{
    public List<GetAllInstallationsDTO> Installations { get; set; }
}