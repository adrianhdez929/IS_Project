using APIAeropuerto.Application.DTOs.Services;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Persistence.Entities;

namespace APIAeropuerto.Domain.Interfaces;

public interface IServiceRepository
{
    Task<ServiceDTO> CreateRepairService(CreateRepairServiceDTO dto, CancellationToken ct);
    Task<ServicesEntity> CreateService(ServicesPersistence entity, CancellationToken ct);
    Task<ServicesEntity> GetOneService(Guid id);
    Task UpdateService(Guid id, ServicesEntity entity,CancellationToken ct);
    
    Task<GetAllClientsServiceDTO> GetAllClientsService(Guid id,CancellationToken ct);
    
    Task<IEnumerable<GetAllServicesDTO>> GetAllServices(CancellationToken ct = default);
}