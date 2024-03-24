using APIAeropuerto.Application.DTOs.Services;
using APIAeropuerto.Domain.Interfaces;
using AutoMapper;

namespace APIAeropuerto.Application.UseCases.RepairService;

public class CreateRepairServiceUseCase : IUseCase<ServiceDTO,CreateRepairServiceDTO>
{
    private readonly IServiceRepository _repository;
    private readonly IMapper _mapper;
    
    public CreateRepairServiceUseCase(IServiceRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<ServiceDTO> Execute(CreateRepairServiceDTO dto, CancellationToken ct = default)
    {
        return await _repository.CreateRepairService(dto,ct);
    }
}