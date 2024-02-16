using APIAeropuerto.Application.DTOs.Services;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Domain.Interfaces;
using AutoMapper;

namespace APIAeropuerto.Application.UseCases.Services;

public class GetAllServicesUseCase
{
    private readonly IBaseRepository<ServicesEntity> _repository;
    private readonly IMapper _mapper;

    public GetAllServicesUseCase(IBaseRepository<ServicesEntity> repository,IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ServiceDTO>> Execute()
    {
        var temp = await _repository.GetAll();
        return _mapper.Map<IEnumerable<ServiceDTO>>(temp);
    }
}