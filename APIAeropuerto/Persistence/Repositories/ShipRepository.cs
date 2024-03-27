using APIAeropuerto.Application.DTOs.Ship;
using APIAeropuerto.Application.Exceptions.NotFound;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Domain.Interfaces;
using APIAeropuerto.Persistence.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace APIAeropuerto.Persistence.Repositories;

public class ShipRepository : BaseRepository<ShipEntity,ShipPersistence,CoreDbContext>, IShipRepository
{
    public ShipRepository(CoreDbContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<ShipDTO> CreateShip(CreateShipDTO entity, CancellationToken ct = default)
    {
        var propietary = await _context.Clients.FirstOrDefaultAsync(x => x.Id == entity.PropietaryId, ct);
        if (propietary == null) throw new NotFoundException("Propietary not found");
        await using var transaction = await _context.Database.BeginTransactionAsync(ct);
        try
        {
            var domain = ShipEntity.Create(entity.Tuition, entity.Clasification, entity.PassengersAmmount, entity.TripulationAmmount, entity.Capacity);
            if (!domain.IsSuccess) throw new Exception(domain.ErrorMessage);
            var p = await _context.Ships.AddAsync(new ShipPersistence
            {
                Tuition = domain.Value.Tuition,
                Clasification = domain.Value.Clasification,
                PassengersAmmount = domain.Value.PassengersAmmount,
                TripulationAmmount = domain.Value.TripulationAmmount,
                Capacity = domain.Value.Capacity,
                Propietary = propietary,
                Created = domain.Value.Created,
                Updated = domain.Value.Updated
            }, ct);
            await _context.SaveChangesAsync(ct);
            await transaction.CommitAsync(ct);
            return _mapper.Map<ShipDTO>(p.Entity);
        }
        catch (Exception e)
        {
            await transaction.RollbackAsync(ct);
            throw new Exception(e.Message);
        }
    }

    public async Task<ShipDTO> GetOneShip(GetOneShipDTO entity, CancellationToken ct = default)
    {
        var p = await _context.Ships
            .Include(x => x.Propietary)
            .FirstOrDefaultAsync(x => x.Id == entity.Id, ct);
        if (p == null) throw new NotFoundException("Ship not found");
        return _mapper.Map<ShipDTO>(p);
    }

    public async Task<IEnumerable<GetAllShipDTO>> GetAllShips(CancellationToken ct = default)
    {
        var p = await _context.Ships
            .Include(x => x.Propietary)
            .ToListAsync(ct);
        return _mapper.Map<IEnumerable<GetAllShipDTO>>(p);
    }
}