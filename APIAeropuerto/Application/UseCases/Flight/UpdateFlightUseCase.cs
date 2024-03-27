using APIAeropuerto.Application.DTOs.Flight;
using APIAeropuerto.Application.Exceptions.NotFound;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Domain.Interfaces;
using AutoMapper;

namespace APIAeropuerto.Application.UseCases.Flight;

public class UpdateFlightUseCase : IUseCase<FlightDTO,UpdateFlightDTO>
{
    private readonly IFlightRepository _repository;

    public UpdateFlightUseCase(IFlightRepository repository)
    {
        _repository = repository;
    }
    public async Task<FlightDTO> Execute(UpdateFlightDTO dto, CancellationToken ct = default)
    {
        var result = await _repository.UpdateFlight(dto,ct);
        if (result is null)
            throw new NotFoundException("Flight not can be updated");
        return result;
    }
}