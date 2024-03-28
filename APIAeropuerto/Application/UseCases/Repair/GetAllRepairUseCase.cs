using APIAeropuerto.Application.DTOs.Repair;
using APIAeropuerto.Domain.Interfaces;

namespace APIAeropuerto.Application.UseCases.Repair;

public class GetAllRepairUseCase
{
    private readonly IRepairRepository _repairRepository;
    
    public GetAllRepairUseCase(IRepairRepository repairRepository)
    {
        _repairRepository = repairRepository;
    }
    public async Task<IEnumerable<RepairDTO>> Execute(CancellationToken ct = default)
    {
        var repairs = await _repairRepository.GetAllRepairs();
        return repairs;
    }
}