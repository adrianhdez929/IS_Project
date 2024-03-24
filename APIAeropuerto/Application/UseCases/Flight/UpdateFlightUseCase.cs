using APIAeropuerto.Application.DTOs.Flight;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Domain.Interfaces;
using AutoMapper;

namespace APIAeropuerto.Application.UseCases.Flight;

public class UpdateFlightUseCase : IUseCase<FlightDTO,UpdateFlightDTO>
{
    private readonly IFlightRepository _repository;
    private readonly IMapper _mapper;
    
    public UpdateFlightUseCase(IFlightRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<FlightDTO> Execute(UpdateFlightDTO dto, CancellationToken ct = default)
    {
        var result = await _repository.UpdateFlight(dto,ct);
        if (result is null)
            throw new Exception("Flight not can be updated");
        return result;
    }
}