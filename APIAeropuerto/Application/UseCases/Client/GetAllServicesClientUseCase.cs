using APIAeropuerto.Application.DTOs.Client;
using APIAeropuerto.Domain.Interfaces;
using AutoMapper;

namespace APIAeropuerto.Application.UseCases.Client;

public class GetAllServicesClientUseCase : IUseCase<GetlAllServicesClientDTO,GetOneClientDTO>
{
    private readonly IClientRepository _repository;
    private readonly IMapper _mapper;
    
    public GetAllServicesClientUseCase(IClientRepository repository,IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<GetlAllServicesClientDTO> Execute(GetOneClientDTO dto, CancellationToken ct = default)
    {
        var temp = await _repository.GetServicesClient(dto.Id, ct);
        if (temp == null) throw new Exception("Client not Found");
        return temp;
    }
}