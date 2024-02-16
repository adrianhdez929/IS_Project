using APIAeropuerto.Application.DTOs.Airport;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Domain.Interfaces;
using AutoMapper;

namespace APIAeropuerto.Application.UseCases.Airport;

public class GetOneAirportUseCase : IUseCase<AirportDTO,GetOneAirportDTO>
{
    private readonly IBaseRepository<AirportEntity> _repository;
    private readonly IMapper _mapper;

    public GetOneAirportUseCase(IBaseRepository<AirportEntity> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<AirportDTO> Execute(GetOneAirportDTO dto, CancellationToken ct = default)
    {
        var airport = await _repository.GetOne(dto.Id, ct);
        return _mapper.Map<AirportDTO>(airport);
    }
}