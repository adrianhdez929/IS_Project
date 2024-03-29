using APIAeropuerto.Domain.Entities;

namespace APIAeropuerto.Domain.Interfaces;

public interface IServiceTypeRepository
{
    Task<ServiceTypeEntity> GetOneServiceType(Guid id, CancellationToken ct);
}