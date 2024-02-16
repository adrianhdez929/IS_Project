using APIAeropuerto.Application.DTOs.ClientService;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Domain.Interfaces;
using APIAeropuerto.Persistence.Entities;
using AutoMapper;

namespace APIAeropuerto.Persistence.Repositories;

public class ClientServiceRepository : BaseRepository<ClientServicesEntity,ClientServicesPersistence,CoreDbContext>,IClientServiceRepository
{
    public ClientServiceRepository(CoreDbContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task DeleteClientService(DeleteClientServiceDTO dto, CancellationToken ct)
    {
        var temp = await _table.FindAsync(dto.IdClient, dto.IdService);
        if (temp is null) throw new Exception("El servicio no esta asignado al ciente indicado");
        _table.Remove(temp);
        await _context.SaveChangesAsync(ct);
    }
}