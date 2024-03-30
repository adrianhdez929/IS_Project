using APIAeropuerto.Domain.Entities;

namespace APIAeropuerto.Domain.Interfaces;

public interface IInstallationTypeRepository
{
    Task<InstallationTypeEntity> GetOneInstallationType(Guid id, CancellationToken ct = default);
}