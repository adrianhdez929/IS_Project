using APIAeropuerto.Application.DTOs.Repair;
using APIAeropuerto.Application.Exceptions.NotFound;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Domain.Interfaces;

namespace APIAeropuerto.Application.UseCases.Repair;

public class DeleteRepairUseCase : IUseCase<string,DeleteRepairDTO>
{
    private readonly IBaseRepository<RepairEntity> _repairRepository;
    
    public DeleteRepairUseCase(IBaseRepository<RepairEntity> repairRepository)
    {
        _repairRepository = repairRepository;
    }
    public async Task<string> Execute(DeleteRepairDTO dto, CancellationToken ct = default)
    {
        var repair = await _repairRepository.GetOne(dto.Id,ct);
        if (repair is null) throw new NotFoundException("Repair not found");
        await _repairRepository.Delete(dto.Id,ct);
        return "Repair deleted";
    }
}