using APIAeropuerto.Application.DTOs.Installations;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Domain.Interfaces;
using APIAeropuerto.Persistence.Entities;
using AutoMapper;

namespace APIAeropuerto.Application.UseCases.Installations;

public class CreateInstallationUseCase : IUseCase<InstallationDTO,CreateInstallationsDTO>
{
    private readonly IInstallationRepository _repository;
    private readonly IAirportRepository _airportRepository;
    private readonly IMapper _mapper;

    public CreateInstallationUseCase(IInstallationRepository repository,IAirportRepository airportRepository,IMapper mapper)
    {
        _repository = repository;
        _airportRepository = airportRepository;
        _mapper = mapper;
    }
    public async Task<InstallationDTO> Execute(CreateInstallationsDTO dto, CancellationToken ct = default)
    {
        var a = await _airportRepository.GetOneAirport(dto.IdAirport, ct);
        var i = InstallationsEntity.Create(dto.Name, dto.Description, dto.Location, dto.Type, a);
        if(!i.IsSuccess) throw new Exception(i.ErrorMessage);
        await _repository.CreateInstallations(_mapper.Map<InstallationsPersistence>(i.Value), ct);
        return _mapper.Map<InstallationDTO>(i.Value);
    }
}