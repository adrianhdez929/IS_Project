using APIAeropuerto.Application.DTOs.Installations;
using APIAeropuerto.Application.Exceptions.NotFound;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Domain.Interfaces;
using APIAeropuerto.Persistence.Entities;
using AutoMapper;

namespace APIAeropuerto.Application.UseCases.Installations;

public class CreateInstallationUseCase : IUseCase<InstallationDTO,CreateInstallationsDTO>
{
    private readonly IInstallationRepository _repository;
    private readonly IAirportRepository _airportRepository;
    private readonly IBaseRepository<InstallationTypeEntity> _installationTypeRepository;
    private readonly IMapper _mapper;

    public CreateInstallationUseCase(IInstallationRepository repository,
        IAirportRepository airportRepository,
        IBaseRepository<InstallationTypeEntity> installationTypeRepository,
        IMapper mapper)
    {
        _repository = repository;
        _airportRepository = airportRepository;
        _installationTypeRepository = installationTypeRepository;
        _mapper = mapper;
    }
    public async Task<InstallationDTO> Execute(CreateInstallationsDTO dto, CancellationToken ct = default)
    {
        var it = await _installationTypeRepository.GetOne(dto.IdInstallationType, ct);
        if(it is null) throw new NotFoundException("Installation type not found");
        var a = await _airportRepository.GetOneAirport(dto.IdAirport, ct);
        var i = InstallationsEntity.Create(dto.Name, dto.Description, dto.Location,a);
        if(!i.IsSuccess) throw new Exception(i.ErrorMessage);
        i.Value!.InstallationType = it;
        await _repository.CreateInstallations(_mapper.Map<InstallationsPersistence>(i.Value), ct);
        return _mapper.Map<InstallationDTO>(i.Value);
    }
}