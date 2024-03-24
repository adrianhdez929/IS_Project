using APIAeropuerto.Application.DTOs.Ship;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Domain.Interfaces;
using AutoMapper;

namespace APIAeropuerto.Application.UseCases.Ship;

public class GetOneShipUseCase : IUseCase<ShipDTO,GetOneShipDTO>
{
    private readonly  IShipRepository _repository;
    private readonly IMapper _mapper;
    
    public GetOneShipUseCase(IShipRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<ShipDTO> Execute(GetOneShipDTO dto, CancellationToken ct = default)
    {
        var p = await _repository.GetOneShip(dto, ct);
        return p;
    }
}