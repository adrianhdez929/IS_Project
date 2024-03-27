using APIAeropuerto.Application.DTOs.Installations;
using APIAeropuerto.Application.Exceptions.NotFound;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Domain.Interfaces;
using APIAeropuerto.Persistence.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace APIAeropuerto.Persistence.Repositories;

public class InstallationsRepository : BaseRepository<InstallationsEntity,InstallationsPersistence,CoreDbContext>,IInstallationRepository
{
    public InstallationsRepository(CoreDbContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public virtual async Task<InstallationsEntity> CreateInstallations(InstallationsPersistence entity, CancellationToken ct)
    {
        var a = await _context.Airports.Include(x => x.Installations)
            .FirstOrDefaultAsync(x => x.Id == entity.Airport.Id, ct);
        if (a is null) throw new NotFoundException("Airport not Found");
        entity.Airport = null!;
        _context.Installations.Add(entity);
        var temp = a.Installations?.ToList() ?? new List<InstallationsPersistence>();
        temp.Add(entity);
        a.Installations = temp;
        
        await _context.SaveChangesAsync(ct);
        return _mapper.Map<InstallationsEntity>(entity);
    }

    public virtual async Task<GetInstallationServicesDTO> GetServices(Guid id, CancellationToken ct)
    {
        var temp = await _context.Installations.Include(x => x.Services).AsNoTracking()
            .FirstOrDefaultAsync(y => y.Id == id, ct);
        return temp == null ? null! : _mapper.Map<GetInstallationServicesDTO>(temp);
    }

    public virtual async Task<InstallationsEntity> GetOneInstallation(Guid id, CancellationToken ct)
    {
        var temp = await _context.Installations.Include(x => x.Services).AsNoTracking()
            .FirstOrDefaultAsync(y => y.Id == id, ct);
        if (temp == null) throw new NotFoundException("Installation not Found");
        return _mapper.Map<InstallationsEntity>(temp);
    }
}