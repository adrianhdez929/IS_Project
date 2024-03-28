using APIAeropuerto.Application.DTOs.Repair;
using APIAeropuerto.Domain.Interfaces;

namespace APIAeropuerto.Application.UseCases.Repair;

public class GetAllServicesShipUseCase : IUseCase<GetAllServicesShipDTO,GetAllServicesShipDTO>
{
    private readonly IRepairRepository _repairRepository;
    
    public GetAllServicesShipUseCase(IRepairRepository repairRepository)
    {
        _repairRepository = repairRepository;
    }
    public async Task<GetAllServicesShipDTO> Execute(GetAllServicesShipDTO dto, CancellationToken ct = default)
    {
        var services = await _repairRepository.GetAllServicesShip(dto.IdShip);
        dto.Services = services;
        return dto;
    }
}