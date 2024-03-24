using APIAeropuerto.Application.DTOs.Flight;
using APIAeropuerto.Domain.Interfaces;

namespace APIAeropuerto.Application.UseCases.Flight;

public class GetOneFlightUseCase : IUseCase<FlightDTO,GetOneFlightDTO>
{
    private readonly IFlightRepository _repository;
    
    public GetOneFlightUseCase(IFlightRepository repository)
    {
        _repository = repository;
    }
    public async Task<FlightDTO> Execute(GetOneFlightDTO dto, CancellationToken ct = default)
    {
        var result = await _repository.GetOneFlight(dto,ct);
        return result;
    }
}