using APIAeropuerto.Application.Exceptions.NotFound;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Domain.Interfaces;
using APIAeropuerto.Persistence.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace APIAeropuerto.Persistence.Repositories;

public class InstallationTypeRepository : BaseRepository<InstallationTypeEntity,InstallationTypePersistence,CoreDbContext> , IInstallationTypeRepository
{
    public InstallationTypeRepository(CoreDbContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<InstallationTypeEntity> GetOneInstallationType(Guid id, CancellationToken ct = default)
    {
        var result = await _context.InstallationTypes.AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id,ct);
        if (result == null) throw new NotFoundException("ServiceType not Found");
        return _mapper.Map<InstallationTypeEntity>(result);
    }
}