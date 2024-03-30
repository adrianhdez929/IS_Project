using APIAeropuerto.Application.DTOs.InstallationType;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Domain.Interfaces;
using AutoMapper;

namespace APIAeropuerto.Application.UseCases.InstallationType;

public class GetOneInstallationTypeUseCase: IUseCase<InstallationTypeDTO,GetOneInstallationTypeDTO>
{
    private readonly IBaseRepository<InstallationTypeEntity> _repository;
    private readonly IMapper _mapper;
    
    public GetOneInstallationTypeUseCase(IBaseRepository<InstallationTypeEntity> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<InstallationTypeDTO> Execute(GetOneInstallationTypeDTO dto, CancellationToken ct = default)
    {
        var result = await _repository.GetOne(dto.Id, ct);
        return _mapper.Map<InstallationTypeDTO>(result);
    }
}