using APIAeropuerto.Application.DTOs.Flight;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Domain.Interfaces;
using APIAeropuerto.Persistence.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace APIAeropuerto.Persistence.Repositories;

public class FlightRepository : BaseRepository<FlightEntity,FlightPersistence,CoreDbContext>, IFlightRepository
{
    public FlightRepository(CoreDbContext context, IMapper mapper) : base(context, mapper)
    {
    }

    private async Task<bool> AddOriginAirport(Guid flightId, Guid airportId, CancellationToken ct = default)
    {
        var flight = await _context.Flights.FindAsync(flightId, ct);
        var airport = await _context.Airports.FindAsync(airportId, ct);
        if(flight is null || airport is null) return false;
        flight.AirportOrigin = airport;
        return true;
    }

    private async Task<bool> AddDestinationAirport(Guid flightId, Guid airportId, CancellationToken ct = default)
    {
        var flight = await _context.Flights.FindAsync(flightId, ct);
        var airport = await _context.Airports.FindAsync(airportId, ct);
        if(flight is null || airport is null) return false;
        flight.AirportDestination = airport;
        return true;
    }

    private async Task<bool> AddShip(Guid flightId, Guid shipId, CancellationToken ct = default)
    {
        var flight = await _context.Flights.FindAsync(flightId, ct);
        var ship = await _context.Ships.FindAsync(shipId, ct);
        if(flight is null || ship is null) return false;
        flight.Ship = ship;
        return true;
    }

    private async Task<bool> AddClient(Guid flightId, Guid clientId, CancellationToken ct = default)
    {
        var flight = await _context.Flights.FindAsync(flightId, ct);
        var client = await _context.Clients.FindAsync(clientId, ct);
        if(flight is null || client is null) return false;
        flight.Client = client;
        return true;
    }

    public async Task<FlightDTO> CreateFlight(CreateFlightDTO dto, CancellationToken ct = default)
    {
        var flight = FlightEntity.Create(dto.DepartureDate, dto.ArrivalDate);
        if(!flight.IsSuccess) throw new Exception(flight.ErrorMessage);
        await using var transaction = await _context.Database.BeginTransactionAsync(ct);
        var result = await _context.Flights.AddAsync(_mapper.Map<FlightPersistence>(flight.Value), ct);
        if (!await AddOriginAirport(result.Entity.Id, dto.AirportOrigin, ct))
        {
            transaction.Rollback();
            throw new Exception("Error adding origin airport");
        }
        if (!await AddDestinationAirport(result.Entity.Id, dto.AirportDestination, ct))
        {
            transaction.Rollback();
            throw new Exception("Error adding destination airport");
        }
        if (!await AddShip(result.Entity.Id, dto.Ship, ct))
        {
            transaction.Rollback();
            throw new Exception("Error adding ship");
        }
        if (!await AddClient(result.Entity.Id, dto.Client, ct))
        {
            transaction.Rollback();
            throw new Exception("Error adding client");
        }
        await transaction.CommitAsync(ct);
        await _context.SaveChangesAsync(ct);
        return _mapper.Map<FlightDTO>(result.Entity);
    }

    public async Task<FlightDTO> UpdateFlight(UpdateFlightDTO dto, CancellationToken ct = default)
    {
        var flight = await _context.Flights.FindAsync(dto.Id, ct);
        if(flight is null) throw new Exception("Flight not found");
        var airportOrigin = await _context.Airports.FindAsync(dto.AirportOrigin, ct);
        if(airportOrigin is null) throw new Exception("Origin airport not found");
        var airportDestination = await _context.Airports.FindAsync(dto.AirportDestination, ct);
        if(airportDestination is null) throw new Exception("Destination airport not found");
        var ship = await _context.Ships.FindAsync(dto.Ship, ct);
        if(ship is null) throw new Exception("Ship not found");
        flight.DepartureDate = dto.DepartureDate;
        flight.ArrivalDate = dto.ArrivalDate;
        flight.AirportOrigin = airportOrigin;
        flight.AirportDestination = airportDestination;
        flight.Ship = ship;
        flight.Updated = DateTime.Now;
        await _context.SaveChangesAsync(ct);
        return _mapper.Map<FlightDTO>(flight);
    }

    public async Task<FlightDTO> GetOneFlight(GetOneFlightDTO dto, CancellationToken ct = default)
    {
        var flight = await _context.Flights.Include(x=> x.AirportOrigin ).Include(x=> x.AirportDestination).Include(x=> x.Ship).FirstOrDefaultAsync(x=> x.Id == dto.Id, ct);
        if(flight is null) throw new Exception("Flight not found");
        return _mapper.Map<FlightDTO>(flight);
    }

    public async Task<IEnumerable<GetAllFlightDTO>> GetAllFlights(CancellationToken ct = default)
    {
        var flights = await _context.Flights.Include(x=> x.AirportOrigin ).Include(x=> x.AirportDestination).Include(x=> x.Ship).ToListAsync(ct);
        return _mapper.Map<IEnumerable<GetAllFlightDTO>>(flights);
    }
}