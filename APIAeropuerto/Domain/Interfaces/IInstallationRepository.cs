using APIAeropuerto.Application.DTOs.Installations;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Persistence.Entities;

namespace APIAeropuerto.Domain.Interfaces;

public interface IInstallationRepository : IBaseRepository<InstallationsEntity>
{
    public Task<InstallationsEntity> CreateInstallations(InstallationsPersistence entity, CancellationToken ct);
    public Task<GetInstallationServicesDTO> GetServices(Guid id, CancellationToken ct);
    public Task<InstallationsEntity> GetOneInstallation(Guid id, CancellationToken ct);
}