using APIAeropuerto.Application.DTOs.ClientService;
using APIAeropuerto.Application.DTOs.Services;

namespace APIAeropuerto.Application.DTOs.Client;

public class GetlAllServicesClientDTO
{
    public IEnumerable<ClientServicesDTO> Services { get; set; }
}