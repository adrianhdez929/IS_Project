using APIAeropuerto.Application.DTOs.ServiceType;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Domain.Interfaces;
using AutoMapper;

namespace APIAeropuerto.Application.UseCases.ServiceType;

public class GetAllServiceTypeUseCase
{
    private readonly IBaseRepository<ServiceTypeEntity> _repository;
    private readonly IMapper _mapper;
    
    public GetAllServiceTypeUseCase(IBaseRepository<ServiceTypeEntity> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<GetAllServiceTypeDTO>> Execute( )
    {
        var result = await _repository.GetAll();
        return _mapper.Map<IEnumerable<GetAllServiceTypeDTO>>(result);
    }
}