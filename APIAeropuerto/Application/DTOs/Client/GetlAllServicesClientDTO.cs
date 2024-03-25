using APIAeropuerto.Application.DTOs.Services;

namespace APIAeropuerto.Application.DTOs.Client;

public class GetlAllServicesClientDTO
{
    public IEnumerable<GetAllServicesDTO> Services { get; set; }
}