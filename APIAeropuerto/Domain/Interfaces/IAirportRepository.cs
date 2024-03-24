using APIAeropuerto.Application.DTOs.Airport;
using APIAeropuerto.Domain.Entities;

namespace APIAeropuerto.Domain.Interfaces;

public interface IAirportRepository : IBaseRepository<AirportEntity>
{
    Task<GetAirportInstDTO> GetInstallations(Guid id, CancellationToken ct);
    Task<AirportEntity> GetOneAirport(Guid id, CancellationToken ct);
}