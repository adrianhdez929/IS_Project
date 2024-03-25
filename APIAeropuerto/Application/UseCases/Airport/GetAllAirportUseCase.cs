using APIAeropuerto.Application.DTOs.Airport;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Domain.Interfaces;
using AutoMapper;

namespace APIAeropuerto.Application.UseCases.Airport;

public class GetAllAirportUseCase
{
    private readonly IBaseRepository<AirportEntity> _repository;
    private readonly IMapper _mapper;

    public GetAllAirportUseCase(IBaseRepository<AirportEntity> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<GetAllAirpotDTO>> Execute(CancellationToken ct = default)
    {
        var airports = await _repository.GetAll(ct);
        return _mapper.Map<IEnumerable<GetAllAirpotDTO>>(airports);
    }
}