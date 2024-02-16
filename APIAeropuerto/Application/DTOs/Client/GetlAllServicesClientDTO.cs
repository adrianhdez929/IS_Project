using APIAeropuerto.Application.DTOs.Services;

namespace APIAeropuerto.Application.DTOs.Client;

public class GetlAllServicesClientDTO
{
    public IEnumerable<ServiceDTO> Services { get; set; }
}