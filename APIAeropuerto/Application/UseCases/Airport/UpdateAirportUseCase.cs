using APIAeropuerto.Application.DTOs.Airport;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Domain.Interfaces;
using AutoMapper;

namespace APIAeropuerto.Application.UseCases.Airport;

public class UpdateAirportUseCase : IUseCase<AirportDTO,UpdateAirportDTO>
{
    private readonly IAirportRepository _repository;
    private readonly IMapper _mapper;

    public UpdateAirportUseCase(IAirportRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<AirportDTO> Execute(UpdateAirportDTO dto, CancellationToken ct = default)
    {
        var temp = await _repository.GetOneAirport(dto.Id,ct);
        temp.Update(dto.Name, dto.Address, dto.GeographicPosition);
        await _repository.Put(temp.Id, temp);
        return _mapper.Map<AirportDTO>(temp);
    }
}