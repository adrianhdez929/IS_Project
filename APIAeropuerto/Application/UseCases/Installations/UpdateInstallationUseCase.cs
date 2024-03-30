using APIAeropuerto.Application.DTOs.Installations;
using APIAeropuerto.Application.Exceptions.NotFound;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Domain.Interfaces;
using AutoMapper;

namespace APIAeropuerto.Application.UseCases.Installations;

public class UpdateInstallationUseCase : IUseCase<InstallationDTO,UpdateInstallationDTO>
{
    private readonly IInstallationRepository _repository;
    private readonly IAirportRepository _airportRepository;
    private readonly IInstallationTypeRepository _installationTypeRepository;
    private readonly IMapper _mapper;

    public UpdateInstallationUseCase(IInstallationRepository repository, 
        IAirportRepository airportRepository,
        IInstallationTypeRepository installationTypeRepository,
        IMapper mapper)
    {
        _repository = repository;
        _airportRepository = airportRepository;
        _installationTypeRepository = installationTypeRepository;
        _mapper = mapper;
    }
    public async Task<InstallationDTO> Execute(UpdateInstallationDTO dto, CancellationToken ct = default)
    {
        var a = await _airportRepository.GetOneAirport(dto.IdAirport, ct);
        if(a is null) throw new NotFoundException("Airport not found");
        var it = await _installationTypeRepository.GetOneInstallationType(dto.IdInstallationType, ct);
        if(it is null) throw new NotFoundException("Installation type not found");
        var temp = await _repository.GetOneInstallation(dto.Id,ct);
        temp.Update(dto.Name, dto.Description,dto.Location,a,it);
        temp.InstallationType = it;
        await _repository.UpdateInstallation(temp,ct);
        return _mapper.Map<InstallationDTO>(temp);
    }
}