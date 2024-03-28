using APIAeropuerto.Application.DTOs.Repair;
using APIAeropuerto.Domain.Interfaces;

namespace APIAeropuerto.Application.UseCases.Repair;

public class GetAllShipsRepairUseCase : IUseCase<GetAllShipsRepairDTO,GetAllShipsRepairDTO>
{
    private readonly IRepairRepository _repairRepository;
    
    public GetAllShipsRepairUseCase(IRepairRepository repairRepository)
    {
        _repairRepository = repairRepository;
    }
    public async Task<GetAllShipsRepairDTO> Execute(GetAllShipsRepairDTO dto, CancellationToken ct = default)
    {
        var ships = await _repairRepository.GetAllShipsRepair(dto.IdRepair);
        dto.Ships = ships;
        return dto;
    }
}