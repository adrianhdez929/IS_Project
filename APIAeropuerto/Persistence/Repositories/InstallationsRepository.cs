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
        var it = await _context.InstallationTypes.FirstOrDefaultAsync(x => x.Id == entity.InstallationType.Id, ct);
        if (it is null) throw new NotFoundException("Installation type not Found");
        entity.Airport = null!;
        entity.InstallationType = null!;
        _context.Installations.Add(entity);
        var temp = a.Installations?.ToList() ?? new List<InstallationsPersistence>();
        var temp1 = it.Installations?.ToList() ?? new List<InstallationsPersistence>();
        temp.Add(entity);
        temp1.Add(entity);
        a.Installations = temp;
        it.Installations = temp1;
        
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
        var temp = await _context.Installations.Include(x => x.Services)
            .ThenInclude(y => y.ServiceType)
            .Include(x => x.InstallationType)
            .Include(x => x.Airport).AsNoTracking()
            .FirstOrDefaultAsync(y => y.Id == id);
        if (temp == null) throw new NotFoundException("Installation not Found");
        return _mapper.Map<InstallationsEntity>(temp);
    }

    public async Task<IEnumerable<GetAllInstallationsDTO>> GetAllInstallations(CancellationToken ct)
    {
        var temp = await _context.Installations.Include(x => x.Airport)
            .Include(x => x.InstallationType)
            .ToListAsync();
        return _mapper.Map<IEnumerable<GetAllInstallationsDTO>>(temp);
    }

    public async Task<IEnumerable<InstallationDTO>> GetAllInstallationsWithRepairServices(CancellationToken ct)
    {
        var installations = await _context.Installations.Include(x => x.Services)
            .Include(x => x.Airport)
            .Where(x =>x.Services.Any(z => z.ServiceType.Type == "Repair"))
            .ToListAsync();
        
        return _mapper.Map<IEnumerable<InstallationDTO>>(installations);
    }

    public async Task UpdateInstallation(InstallationsEntity entity, CancellationToken ct)
    {
        if (entity is null) throw new ArgumentNullException(nameof(entity), "Installation cannot be null");

        var existingEntity = await _table.Include(x => x.InstallationType)
            .Include(x => x.Airport)
            .FirstOrDefaultAsync(x => x.Id == entity.Id, ct);
        if (existingEntity is null) throw new NotFoundException($"Error: Installation with id {entity.Id} Not Found");

        var updatedEntity = _mapper.Map<InstallationsEntity, InstallationsPersistence>(entity);
        _context.Entry(existingEntity).CurrentValues.SetValues(updatedEntity);
        if(existingEntity.InstallationType.Id != updatedEntity.InstallationType.Id)
            existingEntity.InstallationType = updatedEntity.InstallationType;
        if(existingEntity.Airport.Id != updatedEntity.Airport.Id)
            existingEntity.Airport = updatedEntity.Airport;
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