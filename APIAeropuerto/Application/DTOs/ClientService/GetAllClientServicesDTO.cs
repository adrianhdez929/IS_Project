using APIAeropuerto.Application.DTOs.Services;

namespace APIAeropuerto.Application.DTOs.ClientService;

public class ClientServicesDTO : ServiceDTO
{
    public Guid Id { get; set; }
    public string Comments { get; set; }
    public float Rating { get; set; }
}