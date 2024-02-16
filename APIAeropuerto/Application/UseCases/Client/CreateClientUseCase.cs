using APIAeropuerto.Application.DTOs.Client;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Domain.Interfaces;
using AutoMapper;

namespace APIAeropuerto.Application.UseCases.Client;

public class CreateClientUseCase : IUseCase<ClientDTO,CreateClientDTO>
{
    private readonly IClientRepository _repository;
    private readonly IMapper _mapper;
    
    public CreateClientUseCase(IClientRepository repository,IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<ClientDTO> Execute(CreateClientDTO dto, CancellationToken ct = default)
    {
        var temp = ClientEntity.Create(dto.Name, dto.Nationality, dto.Type);
        if(!temp.IsSuccess) throw new Exception(temp.ErrorMessage);
        await _repository.Create(temp.Value,ct);
        return _mapper.Map<ClientDTO>(temp.Value);
    }
}