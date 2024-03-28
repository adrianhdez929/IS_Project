using APIAeropuerto.Application.DTOs.Repair;
using APIAeropuerto.Application.Exceptions.NotFound;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Domain.Interfaces;
using AutoMapper;

namespace APIAeropuerto.Application.UseCases.Repair;

public class UpdateRepairUseCase : IUseCase<RepairDTO,UpdateRepairDTO>
{
    private readonly IBaseRepository<RepairEntity> _repairRepository;
    private readonly IMapper _mapper;
    
    public UpdateRepairUseCase(IBaseRepository<RepairEntity> repairRepository, IMapper mapper)
    {
        _repairRepository = repairRepository;
        _mapper = mapper;
    }
    public async Task<RepairDTO> Execute(UpdateRepairDTO dto, CancellationToken ct = default)
    {
        var repair = _repairRepository.GetOne(dto.Id);
        if (repair is null)
            throw new NotFoundException("Repair not found");
        var repairEntity = _mapper.Map<RepairEntity>(dto);
        await _repairRepository.Put(dto.Id, repairEntity,ct);
        return _mapper.Map<RepairDTO>(repairEntity);
    }
}