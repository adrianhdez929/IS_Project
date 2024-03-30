using APIAeropuerto.Application.DTOs.Client;
using APIAeropuerto.Domain.Entities;

namespace APIAeropuerto.Domain.Interfaces;

public interface IClientRepository : IBaseRepository<ClientEntity>
{
    Task<ClientEntity> GetOneClient(Guid id, CancellationToken ct);
    Task<GetlAllServicesClientDTO> GetServicesClient(Guid id, CancellationToken ct);
    Task AddService(ClientServicesEntity dto, CancellationToken ct);
    Task<IEnumerable<GetAllClientDTO>> GetAllClients(CancellationToken ct);
    
    Task UpdateClient(ClientEntity entity, CancellationToken ct);
}