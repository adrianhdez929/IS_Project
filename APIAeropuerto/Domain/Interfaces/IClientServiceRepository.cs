using APIAeropuerto.Application.DTOs.ClientService;
using APIAeropuerto.Domain.Entities;

namespace APIAeropuerto.Domain.Interfaces;

public interface IClientServiceRepository : IBaseRepository<ClientServicesEntity>
{ Task DeleteClientService(DeleteClientServiceDTO dto, CancellationToken ct);
}