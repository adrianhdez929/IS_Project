using APIAeropuerto.Application.DTOs.Ship;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Domain.Interfaces;
using AutoMapper;

namespace APIAeropuerto.Application.UseCases.Ship;

public class CreateShipUseCase : IUseCase<ShipDTO,CreateShipDTO>
{
    private readonly IShipRepository _repository;
    private readonly IMapper _mapper;
    
    public CreateShipUseCase(IShipRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<ShipDTO> Execute(CreateShipDTO dto, CancellationToken ct = default)
    {
        var p = await _repository.CreateShip(dto, ct);
        return p;
    }
}