using APIAeropuerto.Application.DTOs.Ship;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Domain.Interfaces;
using AutoMapper;

namespace APIAeropuerto.Application.UseCases.Ship;

public class CreateShipUseCase : IUseCase<ShipDTO,CreateShipDTO>
{
    private readonly IShipRepository _repository;

    public CreateShipUseCase(IShipRepository repository)
    {
        _repository = repository;
    }
    public async Task<ShipDTO> Execute(CreateShipDTO dto, CancellationToken ct = default)
    {
        var p = await _repository.CreateShip(dto, ct);
        return p;
    }
}