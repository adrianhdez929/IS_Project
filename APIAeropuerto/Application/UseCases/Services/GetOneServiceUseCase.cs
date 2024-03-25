using APIAeropuerto.Application.DTOs.Services;
using APIAeropuerto.Domain.Interfaces;
using AutoMapper;

namespace APIAeropuerto.Application.UseCases.Services;

public class GetOneServiceUseCase : IUseCase<ServiceDTO,GetOneServiceDTO>
{
    private readonly IServiceRepository _repository;
    private readonly IMapper _mapper;

    public GetOneServiceUseCase(IServiceRepository repository,IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ServiceDTO> Execute(GetOneServiceDTO dto, CancellationToken ct = default)
    {
        var temp = await _repository.GetOneService(dto.Id);
        return _mapper.Map<ServiceDTO>(temp);
    }    
}