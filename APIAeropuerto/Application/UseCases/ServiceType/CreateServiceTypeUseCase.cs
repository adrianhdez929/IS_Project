using APIAeropuerto.Application.DTOs.ServiceType;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Domain.Interfaces;
using AutoMapper;

namespace APIAeropuerto.Application.UseCases.ServiceType;

public class CreateServiceTypeUseCase : IUseCase<ServiceTypeDTO,CreateServiceTypeDTO>
{
    private readonly IBaseRepository<ServiceTypeEntity> _repository;
    private readonly IMapper _mapper;

    public CreateServiceTypeUseCase(IBaseRepository<ServiceTypeEntity> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<ServiceTypeDTO> Execute(CreateServiceTypeDTO dto, CancellationToken ct = default)
    {
        var entity = ServiceTypeEntity.Create(dto.Type);
        await _repository.Create(entity, ct);
        return _mapper.Map<ServiceTypeDTO>(entity);
    }
}