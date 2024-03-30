using APIAeropuerto.Application.DTOs.Client;
using APIAeropuerto.Application.Exceptions.NotFound;
using APIAeropuerto.Domain.Enums;
using APIAeropuerto.Domain.Interfaces;
using AutoMapper;

namespace APIAeropuerto.Application.UseCases.Client;

public class UpdateClientUseCase : IUseCase<ClientDTO,UpdateClientDTO>
{
    private readonly IClientRepository _repository;
    private readonly IClientTypeRepository _clientTypeRepository;
    private readonly IMapper _mapper;
    
    public UpdateClientUseCase(IClientRepository repository,
        IClientTypeRepository clientTypeRepository,
        IMapper mapper)
    {
        _repository = repository;
        _clientTypeRepository = clientTypeRepository;
        _mapper = mapper;
    }
    public async Task<ClientDTO> Execute(UpdateClientDTO dto, CancellationToken ct = default)
    {
        var clt = await _clientTypeRepository.GetOneClientType(dto.IdClientType);
        if(clt is null) throw new NotFoundException("Client type not found");
        var temp = await _repository.GetOneClient(dto.Id,ct);
        temp.Update(dto.Name, dto.Nationality,clt);
        temp.ClientType = clt;
        await _repository.UpdateClient(temp,ct);
        return _mapper.Map<ClientDTO>(temp);
    }
}