using APIAeropuerto.Application.DTOs.Client;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Domain.Interfaces;
using AutoMapper;

namespace APIAeropuerto.Application.UseCases.Client;

public class GetAllClientsUseCase
{
    private readonly IBaseRepository<ClientEntity> _repository;
    private readonly IMapper _mapper;

    public GetAllClientsUseCase(IBaseRepository<ClientEntity> repository,IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ClientDTO>> Execute()
    {
        var temp = await _repository.GetAll();
        return _mapper.Map<IEnumerable<ClientDTO>>(temp);
    }
}