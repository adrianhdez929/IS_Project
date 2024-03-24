using APIAeropuerto.Application.DTOs.Flight;
using APIAeropuerto.Domain.Entities;

namespace APIAeropuerto.Domain.Interfaces;

public interface IFlightRepository
{
    Task<FlightDTO> CreateFlight(CreateFlightDTO dto, CancellationToken ct = default);
    Task<FlightDTO> UpdateFlight(UpdateFlightDTO dto, CancellationToken ct = default);
    Task<FlightDTO> GetOneFlight(GetOneFlightDTO dto, CancellationToken ct = default);
    Task<IEnumerable<FlightDTO>> GetAllFlights(CancellationToken ct = default);
}