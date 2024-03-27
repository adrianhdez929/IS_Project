using APIAeropuerto.Application.DTOs.Airport;
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

    public virtual async Task<GetAirportInstDTO> GetInstallations(Guid id, CancellationToken ct)
    {
        var a = await _context.Airports.Include(x => x.Installations).AsNoTracking()
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