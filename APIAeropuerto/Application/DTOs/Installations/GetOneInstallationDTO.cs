using APIAeropuerto.Application.DTOs.Services;

namespace APIAeropuerto.Application.DTOs.Installations;

public class GetOneInstallationDTO : InstallationDTO
{
    public Guid Id { get; set; }
    public IEnumerable<ServiceDTO> Services { get; set; }
}