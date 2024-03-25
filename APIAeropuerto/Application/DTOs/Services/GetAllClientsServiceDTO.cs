using APIAeropuerto.Application.DTOs.Client;

namespace APIAeropuerto.Application.DTOs.Services;

public class GetAllClientsServiceDTO
{
    public IEnumerable<GetAllClientDTO> Clients { get; set; }
}