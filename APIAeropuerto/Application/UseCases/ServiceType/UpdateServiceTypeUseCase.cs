using APIAeropuerto.Application.DTOs.ServiceType;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Domain.Interfaces;
using AutoMapper;

namespace APIAeropuerto.Application.UseCases.ServiceType;

public class UpdateServiceTypeUseCase : IUseCase<ServiceTypeDTO,UpdateServiceTypeDTO>
{
    private readonly IBaseRepository<ServiceTypeEntity> _repository;
    private readonly IMapper _mapper;
    
    public UpdateServiceTypeUseCase(IBaseRepository<ServiceTypeEntity> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<ServiceTypeDTO> Execute(UpdateServiceTypeDTO dto, CancellationToken ct = default)
    {
        var entity = await _repository.GetOne(dto.Id, ct);
        await _repository.Put(dto.Id,_mapper.Map<ServiceTypeEntity>(dto), ct);
        return _mapper.Map<ServiceTypeDTO>(dto);
    }
}