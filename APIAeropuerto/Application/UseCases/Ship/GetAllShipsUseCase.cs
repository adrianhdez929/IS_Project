using APIAeropuerto.Application.DTOs.Ship;
using APIAeropuerto.Domain.Interfaces;

namespace APIAeropuerto.Application.UseCases.Ship;

public class GetAllShipsUseCase
{
    private readonly IShipRepository _repository;
    
    public GetAllShipsUseCase(IShipRepository repository)
    {
        _repository = repository;
    }
    public async Task<IEnumerable<GetAllShipDTO>> Execute(CancellationToken ct = default)
    {
        return await _repository.GetAllShips(ct);
    }
}