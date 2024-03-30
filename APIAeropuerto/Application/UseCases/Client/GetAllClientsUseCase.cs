using System.Formats.Tar;
using APIAeropuerto.Application.DTOs.Client;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Domain.Interfaces;
using AutoMapper;

namespace APIAeropuerto.Application.UseCases.Client;

public class GetAllClientsUseCase
{
    private readonly IClientRepository _repository;
    private readonly IMapper _mapper;

    public GetAllClientsUseCase(IClientRepository repository,IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GetAllClientDTO>> Execute(CancellationToken ct = default)
    {
        var temp = await _repository.GetAllClients(ct);
        return _mapper.Map<IEnumerable<GetAllClientDTO>>(temp);
    }
}