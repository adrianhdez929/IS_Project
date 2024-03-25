using APIAeropuerto.Application.DTOs.Client;
using APIAeropuerto.Application.DTOs.Services;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Domain.Interfaces;
using APIAeropuerto.Persistence.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace APIAeropuerto.Persistence.Repositories;

public class ClientRepository : BaseRepository<ClientEntity,ClientPersistence,CoreDbContext> , IClientRepository
{
    public ClientRepository(CoreDbContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public virtual async Task<ClientEntity> GetOneClient(Guid id , CancellationToken ct)
    {
        var temp = await _context.Clients.Include(x => x.ClientServices)
            .FirstOrDefaultAsync(x => x.Id == id);
        return temp == null ? null! : _mapper.Map<ClientEntity>(temp);
    }

    public async Task<GetlAllServicesClientDTO> GetServicesClient(Guid id, CancellationToken ct)
    {
        var temp = await _context.Clients.Include(x => x.ClientServices)
            .ThenInclude(x => x.Service)
            .FirstOrDefaultAsync(x => x.Id == id, ct);
        if (temp == null) throw new Exception("Client not Found");
        var services = temp.ClientServices?.Select(x => x.Service);
        return new GetlAllServicesClientDTO()
        {
            Services = _mapper.Map<List<GetAllServicesDTO>>(services)
        };
    }

    public async Task AddService(ClientServicesEntity dto, CancellationToken ct)
    {
        var service = await _context.Services.FirstOrDefaultAsync(x => x.Id == dto.IdService, ct);
        if (service == null) throw new Exception("Service not Found");
        var clientService = _mapper.Map<ClientServicesPersistence>(dto);
        _context.ClientServices.Add(clientService);
        await _context.SaveChangesAsync(ct);
    }
}