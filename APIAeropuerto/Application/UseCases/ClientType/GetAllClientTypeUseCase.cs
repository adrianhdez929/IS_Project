using APIAeropuerto.Application.DTOs.ClientType;
using APIAeropuerto.Application.DTOs.InstallationType;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Domain.Interfaces;
using AutoMapper;

namespace APIAeropuerto.Application.UseCases.ClientType;

public class GetAllClientTypeUseCase
{
    private readonly IBaseRepository<ClientTypeEntity> _repository;
    private readonly IMapper _mapper;
    
    public GetAllClientTypeUseCase(IBaseRepository<ClientTypeEntity> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<GetAllClientTypeDTO>> Execute( )
    {
        var result = await _repository.GetAll();
        return _mapper.Map<IEnumerable<GetAllClientTypeDTO>>(result);
    }
}