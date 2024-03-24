using APIAeropuerto.Application.DTOs.Ship;
using APIAeropuerto.Domain.Entities;

namespace APIAeropuerto.Domain.Interfaces;

public interface IShipRepository
{
    Task<ShipDTO> CreateShip(CreateShipDTO entity, CancellationToken ct = default);
    Task<ShipDTO> GetOneShip(GetOneShipDTO entity, CancellationToken ct = default);
    Task<IEnumerable<ShipDTO>> GetAllShips(CancellationToken ct = default);
}