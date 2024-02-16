using APIAeropuerto.Application.DTOs.Installations;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Domain.Interfaces;
using AutoMapper;

namespace APIAeropuerto.Application.UseCases.Installations;

public class GetOneInstallationUseCase : IUseCase<InstallationDTO,GetOneInstallationDTO>
{
    private readonly IBaseRepository<InstallationsEntity> _repository;
    private readonly IMapper _mapper;

    public GetOneInstallationUseCase(IBaseRepository<InstallationsEntity> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<InstallationDTO> Execute(GetOneInstallationDTO dto, CancellationToken ct = default)
    {
        var temp = await _repository.GetOne(dto.Id, ct);
        return _mapper.Map<InstallationDTO>(temp);
    }
}