using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Domain.Interfaces;
using APIAeropuerto.Persistence.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace APIAeropuerto.Persistence.Repositories;

public class ClientTypeRepository : BaseRepository<ClientTypeEntity,ClientTypePersistence,CoreDbContext> , IClientTypeRepository
{
    public ClientTypeRepository(CoreDbContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<ClientTypeEntity> GetOneClientType(Guid id)
    {
        var clientType = await _context.ClientTypes
            .Include(x => x.Clients)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);

        return _mapper.Map<ClientTypeEntity>(clientType);
    }
}