using APIAeropuerto.Application.DTOs.Airport;
using APIAeropuerto.Application.Exceptions.BadRequest;
using APIAeropuerto.Application.Exceptions.NotFound;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Domain.Interfaces;
using APIAeropuerto.Persistence.Entities;
using AutoMapper;

namespace APIAeropuerto.Application.UseCases.Airport;

public class CreateAirportUseCase : IUseCase<AirportDTO, CreateAirportDTO>
{
    private readonly IAirportRepository _repository;
    private readonly IInstallationTypeRepository _installationTypeRepository;
    private readonly IMapper _mapper;

    public CreateAirportUseCase(IAirportRepository repository, 
        IInstallationTypeRepository installationTypeRepository,
        IMapper mapper)
    {
        _repository = repository;
        _installationTypeRepository = installationTypeRepository;
        _mapper = mapper;
    }
    public async Task<AirportDTO> Execute(CreateAirportDTO dto, CancellationToken ct = default)
    {
        var devices = new List<InstallationsEntity>();
        foreach (var d in dto.Installations)
        {
            var type = await _installationTypeRepository.GetOneInstallationType(d.IdInstallationType, ct);
            if (type is null) throw new NotFoundException("Installation type not found");
            var temp = InstallationsEntity.Create(d.Name, d.Description, d.Location,type);
            if (!temp.IsSuccess) throw new Exception(temp.ErrorMessage);
            devices.Add(temp.Value);
        }
        var domain = AirportEntity.Create(dto.Name, dto.Address, dto.GeographicPosition, devices);
        if (!domain.IsSuccess) throw new Exception(domain.ErrorMessage);
        var p = await _repository.CreateAirport(_mapper.Map<AirportPersistence>(domain.Value), ct);
        return _mapper.Map<AirportDTO>(p);
    }
}