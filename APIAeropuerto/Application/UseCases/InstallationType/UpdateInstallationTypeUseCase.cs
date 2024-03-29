using APIAeropuerto.Application.DTOs.InstallationType;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Domain.Interfaces;
using AutoMapper;

namespace APIAeropuerto.Application.UseCases.InstallationType;

public class UpdateInstallationTypeUseCase : IUseCase<InstallationTypeDTO,UpdateInstallationTypeDTO>
{
    private readonly IBaseRepository<InstallationTypeEntity> _repository;
    private readonly IMapper _mapper;
    
    public UpdateInstallationTypeUseCase(IBaseRepository<InstallationTypeEntity> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<InstallationTypeDTO> Execute(UpdateInstallationTypeDTO dto, CancellationToken ct = default)
    {
        var entity = await _repository.GetOne(dto.Id, ct);
        await _repository.Put(dto.Id,_mapper.Map<InstallationTypeEntity>(dto), ct);
        return _mapper.Map<InstallationTypeDTO>(dto);
    }
}