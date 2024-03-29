using APIAeropuerto.Application.DTOs.ServiceType;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Domain.Interfaces;
using AutoMapper;

namespace APIAeropuerto.Application.UseCases.ServiceType;

public class GetOneServiceTypeUseCase: IUseCase<ServiceTypeDTO,GetOneServiceTypeDTO>
{
    private readonly IBaseRepository<ServiceTypeEntity> _repository;
    private readonly IMapper _mapper;
    
    public GetOneServiceTypeUseCase(IBaseRepository<ServiceTypeEntity> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<ServiceTypeDTO> Execute(GetOneServiceTypeDTO dto, CancellationToken ct = default)
    {
        var result = await _repository.GetOne(dto.Id, ct);
        return _mapper.Map<ServiceTypeDTO>(result);
    }
}