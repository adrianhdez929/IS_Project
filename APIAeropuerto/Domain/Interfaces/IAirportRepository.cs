using APIAeropuerto.Application.DTOs.Airport;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Persistence.Entities;

namespace APIAeropuerto.Domain.Interfaces;

public interface IAirportRepository : IBaseRepository<AirportEntity>
{
    Task<AirportEntity> CreateAirport(AirportPersistence persistence, CancellationToken ct = default);
    Task<GetAirportInstDTO> GetInstallations(Guid id, CancellationToken ct);
    Task<AirportEntity> GetOneAirport(Guid id, CancellationToken ct);
}