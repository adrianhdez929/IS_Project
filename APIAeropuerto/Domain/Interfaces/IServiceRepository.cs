using APIAeropuerto.Application.DTOs.Services;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Persistence.Entities;

namespace APIAeropuerto.Domain.Interfaces;

public interface IServiceRepository
{
    public Task<ServicesEntity> CreateService(ServicesPersistence entity, CancellationToken ct);
    public Task DeleteService(string code);
    public Task<ServicesEntity> GetOneService(string code);
    public Task UpdateService(string code, ServicesEntity entity,CancellationToken ct);
    
    public Task<GetAllClientsServiceDTO> GetAllClientsService(string code,CancellationToken ct);
}