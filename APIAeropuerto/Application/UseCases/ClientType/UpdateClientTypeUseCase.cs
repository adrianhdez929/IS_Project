using APIAeropuerto.Application.DTOs.ClientType;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Domain.Interfaces;
using AutoMapper;

namespace APIAeropuerto.Application.UseCases.ClientType;

public class UpdateClientTypeUseCase : IUseCase<ClientTypeDTO,UpdateClientTypeDTO>
{
    private readonly IBaseRepository<ClientTypeEntity> _repository;
    private readonly IMapper _mapper;
    
    public UpdateClientTypeUseCase(IBaseRepository<ClientTypeEntity> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<ClientTypeDTO> Execute(UpdateClientTypeDTO dto, CancellationToken ct = default)
    {
        var entity = await _repository.GetOne(dto.Id, ct);
        await _repository.Put(dto.Id,_mapper.Map<ClientTypeEntity>(dto), ct);
        return _mapper.Map<ClientTypeDTO>(dto);
    }
}