using APIAeropuerto.Application.DTOs.Flight;
using APIAeropuerto.Domain.Interfaces;
using AutoMapper;

namespace APIAeropuerto.Application.UseCases.Flight;

public class CreateFlightUseCase : IUseCase<FlightDTO,CreateFlightDTO>
{
    private readonly IFlightRepository _repository;
    private readonly IMapper _mapper;
    
    public CreateFlightUseCase(IFlightRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<FlightDTO> Execute(CreateFlightDTO dto, CancellationToken ct = default)
    {
        return await _repository.CreateFlight(dto, ct);
    }
}