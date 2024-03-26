using APIAeropuerto.Application.DTOs.Client;
using APIAeropuerto.Application.Exceptions.NotFound;
using APIAeropuerto.Domain.Enums;
using APIAeropuerto.Domain.Interfaces;
using AutoMapper;

namespace APIAeropuerto.Application.UseCases.Client;

public class UpdateClientUseCase : IUseCase<ClientDTO,UpdateClientDTO>
{
    private readonly IClientRepository _repository;
    private readonly IMapper _mapper;
    
    public UpdateClientUseCase(IClientRepository repository,IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<ClientDTO> Execute(UpdateClientDTO dto, CancellationToken ct = default)
    {
        var temp = await _repository.GetOneClient(dto.Id,ct);
        if (temp == null) throw new NotFoundException("Client not Found");
        temp.Update(dto.Name, dto.Nationality, dto.Type);
        await _repository.Put(dto.Id,temp,ct);
        return _mapper.Map<ClientDTO>(temp);
    }
}