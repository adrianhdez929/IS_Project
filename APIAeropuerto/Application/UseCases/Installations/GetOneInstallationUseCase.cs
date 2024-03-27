using APIAeropuerto.Application.DTOs.Installations;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Domain.Interfaces;
using AutoMapper;

namespace APIAeropuerto.Application.UseCases.Installations;

public class GetOneInstallationUseCase : IUseCase<InstallationDTO,GetOneInstallationDTO>
{
    private readonly IInstallationRepository _repository;
    private readonly IMapper _mapper;

    public GetOneInstallationUseCase(IInstallationRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<InstallationDTO> Execute(GetOneInstallationDTO dto, CancellationToken ct = default)
    {
        var temp = await _repository.GetOneInstallation(dto.Id, ct);
        return _mapper.Map<InstallationDTO>(temp);
    }
}