using APIAeropuerto.Application.DTOs.Repair;
using APIAeropuerto.Application.DTOs.Services;
using APIAeropuerto.Application.DTOs.Ship;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Domain.Interfaces;
using APIAeropuerto.Persistence.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace APIAeropuerto.Persistence.Repositories;

public class RepairRepository : BaseRepository<RepairEntity,RepairPersistence,CoreDbContext>, IRepairRepository
{
    public RepairRepository(CoreDbContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<IEnumerable<GetAllRepairDTO>> GetAllRepairsShip(Guid idShip)
    {
        var repairs = await _context.Repairs.Include(x => x.Service)
            .Include(x => x.Ship)
            .Where(x => x.IdShip == idShip)
            .ToListAsync();
        return _mapper.Map<IEnumerable<GetAllRepairDTO>>(repairs);
    }

    public async Task<RepairDTO> GetOneRepair(Guid id)
    {
        var repair = await _context.Repairs.Include(x => x.Ship)
            .Include(x => x.Service)
            .FirstOrDefaultAsync(x => x.Id == id);
        return _mapper.Map<RepairDTO>(repair);
    }

    public async Task<IEnumerable<GetAllRepairDTO>> GetAllRepairs()
    {
        var repairs = await _context.Repairs.Include(x => x.Ship)
            .Include(x => x.Service)
            .ToListAsync();
        return _mapper.Map<IEnumerable<GetAllRepairDTO>>(repairs);
    }

    public async Task<IEnumerable<GetAllShipDTO>> GetAllShipsRepair(Guid idRepair)
    {
        var ships = await _context.Repairs.Include(x => x.Ship)
            .Where(x => x.IdService == idRepair)
            .Select(x => x.Ship)
            .Distinct()
            .Include(y => y.Propietary)
            .ToListAsync();
        return _mapper.Map<IEnumerable<GetAllShipDTO>>(ships);
    }

    public async Task<IEnumerable<GetAllServicesDTO>> GetAllServicesShip(Guid idShip)
    {
        var services = await _context.Repairs.Include(x => x.Service)
            .ThenInclude(x => x.ServiceType)
            .Include(x => x.Service)
            .ThenInclude(x => x.Installation)
            .Where(x => x.IdShip == idShip)
            .Select(x => x.Service)
            .Distinct()
            .ToListAsync();
        
        return _mapper.Map<IEnumerable<GetAllServicesDTO>>(services);
    }
}