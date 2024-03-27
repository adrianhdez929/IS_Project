using APIAeropuerto.Application.DTOs.Client;
using APIAeropuerto.Application.Exceptions.NotFound;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Domain.Interfaces;
using AutoMapper;

namespace APIAeropuerto.Application.UseCases.Client;

public class GetOneClientUseCase : IUseCase<ClientDTO,GetOneClientDTO>
{
    private readonly IClientRepository _repository;
    private readonly IMapper _mapper;

    public GetOneClientUseCase(IClientRepository repository,IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<ClientDTO> Execute(GetOneClientDTO dto, CancellationToken ct = default)
    {
        var temp = await _repository.GetOneClient(dto.Id,ct);
        if (temp == null) throw new NotFoundException("Client not Found");
        return _mapper.Map<ClientDTO>(temp);
    }
}