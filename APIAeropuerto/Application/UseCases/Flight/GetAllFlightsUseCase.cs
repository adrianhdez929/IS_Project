using APIAeropuerto.Application.DTOs.Flight;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Domain.Interfaces;
using AutoMapper;

namespace APIAeropuerto.Application.UseCases.Flight;

public class GetAllFlightsUseCase
{
    private readonly IFlightRepository _repository;
    private readonly IMapper _mapper;

    public GetAllFlightsUseCase(IFlightRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<GetAllFlightDTO>> Execute(CancellationToken ct = default)
    {
        var result = await _repository.GetAllFlights(ct);
        return _mapper.Map<IEnumerable<GetAllFlightDTO>>(result);
    }
}