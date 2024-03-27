using APIAeropuerto.Application.DTOs.Flight;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Domain.Interfaces;
using AutoMapper;

namespace APIAeropuerto.Application.UseCases.Flight;

public class GetAllFlightsUseCase
{
    private readonly IFlightRepository _repository;

    public GetAllFlightsUseCase(IFlightRepository repository)
    {
        _repository = repository;
    }
    public async Task<IEnumerable<GetAllFlightDTO>> Execute(CancellationToken ct = default)
    {
        var result = await _repository.GetAllFlights(ct);
        return result;
    }
}