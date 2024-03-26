using APIAeropuerto.Application.DTOs.Airport;
using APIAeropuerto.Application.Exceptions.BadRequest;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Domain.Interfaces;
using AutoMapper;

namespace APIAeropuerto.Application.UseCases.Airport;

public class CreateAirportUseCase : IUseCase<AirportDTO, CreateAirportDTO>
{
    private readonly IBaseRepository<AirportEntity> _repository;
    private readonly IMapper _mapper;

    public CreateAirportUseCase(IBaseRepository<AirportEntity> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<AirportDTO> Execute(CreateAirportDTO dto, CancellationToken ct = default)
    {
        var airports = await _repository.GetAll(ct);
        if (airports.Any(a => a.Address == dto.Address)) throw new RepeatBadRequestException("El aeropuerto ya existe");
        var devices = new List<InstallationsEntity>();
        foreach (var d in dto.Installations)
        {
            var temp = InstallationsEntity.Create(d.Name, d.Description, d.Location, d.Type);
            if (!temp.IsSuccess) throw new Exception(temp.ErrorMessage);
            devices.Add(temp.Value);
        }
        var domain = AirportEntity.Create(dto.Name, dto.Address, dto.GeographicPosition, devices);
        if (!domain.IsSuccess) throw new Exception(domain.ErrorMessage);
        var p = await _repository.Create(domain.Value, ct);
        return _mapper.Map<AirportDTO>(p);
    }
}