using APIAeropuerto.Application.DTOs.Client;
using APIAeropuerto.Application.DTOs.ClientService;
using APIAeropuerto.Application.DTOs.Services;
using APIAeropuerto.Application.Exceptions.NotFound;
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
            .Include(x => x.ClientType)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
        return temp == null ? null! : _mapper.Map<ClientEntity>(temp);
    }

    public async Task<GetlAllServicesClientDTO> GetServicesClient(Guid id, CancellationToken ct)
    {
        var temp = await _context.Clients.Include(x => x.ClientServices)
            .ThenInclude(x => x.Service)
            .ThenInclude(x => x.Installation)
            .Include(x => x.ClientServices)
            .ThenInclude(x => x.Service)
            .ThenInclude(x => x.ServiceType)
            .FirstOrDefaultAsync(x => x.Id == id, ct);
        if (temp == null) throw new NotFoundException("Client not Found");
        var services = temp.ClientServices.Where(x => x.IdClient == id).ToList();
        return new GetlAllServicesClientDTO()
        {
            Services = _mapper.Map<List<ClientServicesDTO>>(services)
        };
    }

    public async Task AddService(ClientServicesEntity dto, CancellationToken ct)
    {
        var service = await _context.Services.FirstOrDefaultAsync(x => x.Id == dto.IdService, ct);
        if (service == null) throw new NotFoundException("Service not Found");
        var clientService = _mapper.Map<ClientServicesPersistence>(dto);
        _context.ClientServices.Add(clientService);
        await _context.SaveChangesAsync(ct);
    }

    public async Task<IEnumerable<GetAllClientDTO>> GetAllClients(CancellationToken ct)
    {
        var temp = await _context.Clients.Include(x => x.ClientType)
            .Include(x => x.ClientServices)
            .AsNoTracking()
            .ToListAsync(ct);
        return _mapper.Map<IEnumerable<GetAllClientDTO>>(temp);
    }

    public async Task UpdateClient(ClientEntity entity, CancellationToken ct)
    {
        if (entity is null) throw new ArgumentNullException(nameof(entity), "Client cannot be null");

        var existingEntity = await _table.Include(x => x.ClientType)
            .FirstOrDefaultAsync(x => x.Id == entity.Id, ct);
        if (existingEntity is null) throw new NotFoundException($"Error: Client with id {entity.Id} Not Found");

        var updatedEntity = _mapper.Map<ClientEntity, ClientPersistence>(entity);
        _context.Entry(existingEntity).CurrentValues.SetValues(updatedEntity);
        if(existingEntity.ClientType.Id != updatedEntity.ClientType.Id)
            existingEntity.ClientType = updatedEntity.ClientType;
        _table.Entry(existingEntity).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync(ct);
        }
        catch (DbUpdateException ex)
        {
            throw new InvalidOperationException("A database update exception occurred while saving data", ex);
        }
        catch (Exception ex)
        {
            throw new Exception($"An unexpected error occurred: {ex.Message}", ex);
        }
    }
}