using APIAeropuerto.Application.DTOs.Services;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Domain.Interfaces;
using AutoMapper;

namespace APIAeropuerto.Application.UseCases.Services;

public class GetAllServicesUseCase
{
    private readonly IServiceRepository _repository;
    private readonly IMapper _mapper;

    public GetAllServicesUseCase(IServiceRepository repository,IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GetAllServicesDTO>> Execute()
    {
        var temp = await _repository.GetAllServices();
        return _mapper.Map<IEnumerable<GetAllServicesDTO>>(temp);
    }
}