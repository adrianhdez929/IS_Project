using APIAeropuerto.Application.DTOs.Ship;
using APIAeropuerto.Application.Exceptions.NotFound;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Domain.Interfaces;
using AutoMapper;

namespace APIAeropuerto.Application.UseCases.Ship;

public class UpdateShipUseCase : IUseCase<ShipDTO,UpdateShipDTO>
{
    private readonly IBaseRepository<ShipEntity> _repository;
    private readonly IMapper _mapper;
    
    public UpdateShipUseCase(IBaseRepository<ShipEntity> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<ShipDTO> Execute(UpdateShipDTO dto, CancellationToken ct = default)
    {
        var ship = await _repository.GetOne(dto.Id, ct);
        ship.Update(dto.Clasification,dto.PassengersAmmount,dto.TripulationAmmount,dto.Capacity);
        await _repository.Put(ship.Id,ship, ct);
        return _mapper.Map<ShipDTO>(ship);
    }
}