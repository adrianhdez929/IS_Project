using APIAeropuerto.Application.DTOs.Repair;
using APIAeropuerto.Domain.Interfaces;

namespace APIAeropuerto.Application.UseCases.Repair;

public class GetOneRepairUseCase : IUseCase<RepairDTO,GetOneRepairDTO>
{
    private readonly IRepairRepository _repairRepository;
    
    public GetOneRepairUseCase(IRepairRepository repairRepository)
    {
        _repairRepository = repairRepository;
    }
    public async Task<RepairDTO> Execute(GetOneRepairDTO dto, CancellationToken ct = default)
    {
        var repair = await _repairRepository.GetOneRepair(dto.Id);
        return repair;
    }
}