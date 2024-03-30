using APIAeropuerto.Application.DTOs.Airport;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Domain.Interfaces;
using APIAeropuerto.Persistence.Repositories;
using AutoMapper;

namespace APIAeropuerto.Application.UseCases.Airport;

public class DeleteAirportUseCase:IUseCase<string,DeleteAirportDTO>
{
    private readonly IBaseRepository<AirportEntity> _repository;
    private readonly FlightRepository _flightRepository;

    public DeleteAirportUseCase(IBaseRepository<AirportEntity> repository
    , FlightRepository flightRepository)
    {
        _repository = repository;
        _flightRepository = flightRepository;
    }
    public async Task<string> Execute(DeleteAirportDTO dto, CancellationToken ct = default)
    {
        var flight = await _flightRepository.GetAllFlights();
        var flightService = flight.Where(x=>x.IdAirportOrigin == dto.Id || x.IdAirportDestination == dto.Id).ToList();
        if (flightService.Count > 0)
        {
            foreach (var item in flightService)
            {
                await _flightRepository.Delete(item.Id,ct);
            }
        }
        await _repository.Delete(dto.Id);
        return null!;
    }
}