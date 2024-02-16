using APIAeropuerto.Application.DTOs.Client;
using APIAeropuerto.Domain.Entities;

namespace APIAeropuerto.Domain.Interfaces;

public interface IClientRepository : IBaseRepository<ClientEntity>
{
    public Task<ClientEntity> GetOneClient(Guid id, CancellationToken ct);
    public Task<GetlAllServicesClientDTO> GetServicesClient(Guid id, CancellationToken ct);
    public Task AddService(ClientServicesEntity dto, CancellationToken ct);
}