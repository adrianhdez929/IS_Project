using APIAeropuerto.Application.DTOs.Installations;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Persistence.Entities;

namespace APIAeropuerto.Domain.Interfaces;

public interface IInstallationRepository : IBaseRepository<InstallationsEntity>
{
    Task<InstallationsEntity> CreateInstallations(InstallationsPersistence entity, CancellationToken ct);
    Task<GetInstallationServicesDTO> GetServices(Guid id, CancellationToken ct);
    Task<InstallationsEntity> GetOneInstallation(Guid id, CancellationToken ct);
    Task<IEnumerable<GetAllInstallationsDTO>> GetAllInstallations(CancellationToken ct);
    Task<IEnumerable<InstallationDTO>> GetAllInstallationsWithRepairServices(CancellationToken ct);
    Task UpdateInstallation(InstallationsEntity entity, CancellationToken ct);
}