using APIAeropuerto.Application.Exceptions.NotFound;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Domain.Interfaces;
using APIAeropuerto.Persistence.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace APIAeropuerto.Persistence.Repositories;

public class ServiceTypeRepository : BaseRepository<ServiceTypeEntity,ServiceTypePersistence,CoreDbContext>, IServiceTypeRepository
{
    public ServiceTypeRepository(CoreDbContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<ServiceTypeEntity> GetOneServiceType(Guid id, CancellationToken ct)
    {
        var temp = await _context.ServiceTypes.AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, ct);
        if (temp == null) throw new NotFoundException("ServiceType not Found");
        return _mapper.Map<ServiceTypeEntity>(temp);
    }
}