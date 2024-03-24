using APIAeropuerto.Application.DTOs.Ship;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Domain.Interfaces;

namespace APIAeropuerto.Application.UseCases.Ship;

public class DeleteShipUseCase : IUseCase<string,DeleteShipDTO>
{
    private readonly IBaseRepository<ShipEntity> _repository;
    
    public DeleteShipUseCase(IBaseRepository<ShipEntity> repository)
    {
        _repository = repository;
    }
    public async Task<string> Execute(DeleteShipDTO dto, CancellationToken ct = default)
    {
        var ship = await _repository.GetOne(dto.Id, ct);
        if (ship is null)
            throw new Exception("Ship not found");
        await _repository.Delete(dto.Id, ct);
        return "Ship deleted";
    }
}