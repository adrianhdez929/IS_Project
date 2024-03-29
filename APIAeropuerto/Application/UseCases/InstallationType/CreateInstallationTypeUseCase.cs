using APIAeropuerto.Application.DTOs.InstallationType;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Domain.Interfaces;
using AutoMapper;

namespace APIAeropuerto.Application.UseCases.InstallationType;

public class CreateInstallationTypeUseCase : IUseCase<InstallationTypeDTO,CreateInstallationTypeDTO>
{
    private readonly IBaseRepository<InstallationTypeEntity> _repository;
    private readonly IMapper _mapper;

    public CreateInstallationTypeUseCase(IBaseRepository<InstallationTypeEntity> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<InstallationTypeDTO> Execute(CreateInstallationTypeDTO dto, CancellationToken ct = default)
    {
        var entity = InstallationTypeEntity.Create(dto.Type);
        await _repository.Create(entity, ct);
        return _mapper.Map<InstallationTypeDTO>(entity);
    }
}