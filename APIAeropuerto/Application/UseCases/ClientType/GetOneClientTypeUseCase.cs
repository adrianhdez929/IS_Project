using APIAeropuerto.Application.DTOs.ClientType;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Domain.Interfaces;
using AutoMapper;

namespace APIAeropuerto.Application.UseCases.ClientType;

public class GetOneClientTypeUseCase: IUseCase<ClientTypeDTO,GetOneClientTypeDTO>
{
    private readonly IBaseRepository<ClientTypeEntity> _repository;
    private readonly IMapper _mapper;
    
    public GetOneClientTypeUseCase(IBaseRepository<ClientTypeEntity> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<ClientTypeDTO> Execute(GetOneClientTypeDTO dto, CancellationToken ct = default)
    {
        var result = await _repository.GetOne(dto.Id, ct);
        return _mapper.Map<ClientTypeDTO>(result);
    }
}