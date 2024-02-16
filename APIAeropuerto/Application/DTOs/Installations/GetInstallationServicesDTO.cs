using APIAeropuerto.Application.DTOs.Services;

namespace APIAeropuerto.Application.DTOs.Installations;

public class GetInstallationServicesDTO
{
    public List<ServiceDTO> Services { get; set; }
}