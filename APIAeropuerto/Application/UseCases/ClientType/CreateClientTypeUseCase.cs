using APIAeropuerto.Application.DTOs.ClientType;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Domain.Interfaces;
using AutoMapper;

namespace APIAeropuerto.Application.UseCases.ClientType;

public class CreateClientTypeUseCase : IUseCase<ClientTypeDTO,CreateClientTypeDTO>
{
    private readonly IBaseRepository<ClientTypeEntity> _repository;
    private readonly IMapper _mapper;

    public CreateClientTypeUseCase(IBaseRepository<ClientTypeEntity> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<ClientTypeDTO> Execute(CreateClientTypeDTO dto, CancellationToken ct = default)
    {
        var entity = ClientTypeEntity.Create(dto.Type);
        await _repository.Create(entity, ct);
        return _mapper.Map<ClientTypeDTO>(entity);
    }
}