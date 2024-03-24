using APIAeropuerto.Application.DTOs.Services;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Persistence.Entities;

namespace APIAeropuerto.Domain.Interfaces;

public interface IServiceRepository
{
    Task<ServiceDTO> CreateRepairService(CreateRepairServiceDTO dto, CancellationToken ct);
    Task<ServicesEntity> CreateService(ServicesPersistence entity, CancellationToken ct);
    Task DeleteService(string code);
    Task<ServicesEntity> GetOneService(string code);
    Task UpdateService(string code, ServicesEntity entity,CancellationToken ct);
    
    Task<GetAllClientsServiceDTO> GetAllClientsService(string code,CancellationToken ct);
}