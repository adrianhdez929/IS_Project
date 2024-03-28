using APIAeropuerto.Application.DTOs.Repair;
using APIAeropuerto.Domain.Interfaces;

namespace APIAeropuerto.Application.UseCases.Repair;

public class GetAllRepairsShipUseCase : IUseCase<GetAllRepairsShipDTO,GetAllRepairsShipDTO>
{
    private readonly IRepairRepository _repairRepository;
    
    public GetAllRepairsShipUseCase(IRepairRepository repairRepository)
    {
        _repairRepository = repairRepository;
    }
    public async Task<GetAllRepairsShipDTO> Execute(GetAllRepairsShipDTO dto, CancellationToken ct = default)
    {
        var repairs = await _repairRepository.GetAllRepairsShip(dto.IdShip);
        dto.Repairs = repairs;
        return dto;
    }
}