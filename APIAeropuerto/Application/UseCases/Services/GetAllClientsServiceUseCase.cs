using APIAeropuerto.Application.DTOs.Services;
using APIAeropuerto.Domain.Interfaces;
using AutoMapper;

namespace APIAeropuerto.Application.UseCases.Services;

public class GetAllClientsServiceUseCase : IUseCase<GetAllClientsServiceDTO,GetOneServiceDTO>
{
    private readonly IServiceRepository _repository;
    private readonly IMapper _mapper;
    
    public GetAllClientsServiceUseCase(IServiceRepository repository,IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<GetAllClientsServiceDTO> Execute(GetOneServiceDTO dto, CancellationToken ct = default)
    {
        var temp = await _repository.GetAllClientsService(dto.Id,ct);
        if (temp == null) throw new Exception("Service not Found");
        return temp;
    }
}