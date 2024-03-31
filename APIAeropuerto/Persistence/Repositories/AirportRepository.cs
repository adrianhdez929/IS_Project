using APIAeropuerto.Application.DTOs.Airport;
using APIAeropuerto.Application.Exceptions.BadRequest;
using APIAeropuerto.Application.Exceptions.NotFound;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Domain.Interfaces;
using APIAeropuerto.Persistence.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace APIAeropuerto.Persistence.Repositories;

public class AirportRepository : BaseRepository<AirportEntity,AirportPersistence,CoreDbContext>,IAirportRepository
{
    public AirportRepository(CoreDbContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<AirportEntity> CreateAirport(AirportPersistence persistence, CancellationToken ct = default)
    {
        var airports = await _table.ToListAsync();
        if (airports.Any(a => a.Address == persistence.Address)) throw new RepeatBadRequestException("El aeropuerto ya existe");
        var temp = persistence.Installations;
        persistence.Installations = null!;
        _context.Airports.Add(persistence);
        var installationTypesCache = new Dictionary<Guid, InstallationTypePersistence>();
        foreach (var installation in temp)
        {
            InstallationTypePersistence installationType;
            if (!installationTypesCache.TryGetValue(installation.InstallationType.Id, out installationType))
            {
                installationType = await _context.InstallationTypes.AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Id == installation.InstallationType.Id, ct);
                if (installationType == null) throw new NotFoundException("InstallationType not Found");
        
                installationTypesCache.Add(installation.InstallationType.Id, installationType);
            }

            var tempInstallation = installation;
            tempInstallation.InstallationType = null!;
            tempInstallation.Airport = null!;
            _context.Installations.Add(tempInstallation);
            tempInstallation.InstallationType = installationType;
            tempInstallation.Airport = persistence;
        }

        await _context.SaveChangesAsync(ct);
        return _mapper.Map<AirportEntity>(persistence);
    }

    public virtual async Task<GetAirportInstDTO> GetInstallations(Guid id, CancellationToken ct)
    {
        var a = await _context.Airports.Include(x => x.Installations)
            .ThenInclude(x => x.InstallationType)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, ct);
        return a == null ? null! : _mapper.Map<GetAirportInstDTO>(a);
    }

    public virtual async Task<AirportEntity> GetOneAirport(Guid id, CancellationToken ct)
    {
        var a = await _context.Airports.Include(x => x.Installations).AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id, ct);
        if (a == null) throw new NotFoundException("Airport not Found");
        return _mapper.Map<AirportEntity>(a);
    }
}