using APIAeropuerto.Application.DTOs.Ship;
using APIAeropuerto.Application.Exceptions.NotFound;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Domain.Interfaces;
using APIAeropuerto.Persistence.Repositories;

namespace APIAeropuerto.Application.UseCases.Ship;

public class DeleteShipUseCase : IUseCase<string,DeleteShipDTO>
{
    private readonly IBaseRepository<ShipEntity> _repository;
    private readonly RepairRepository _repairRepository;
    private readonly FlightRepository _flightRepository;
    public DeleteShipUseCase(IBaseRepository<ShipEntity> repository
    , RepairRepository repairRepository
    , FlightRepository flightRepository)
    {
        _repository = repository;
        _repairRepository = repairRepository;
        _flightRepository = flightRepository;
    }
    public async Task<string> Execute(DeleteShipDTO dto, CancellationToken ct = default)
    {
        var repair = await _repairRepository.GetAllRepairs();
        var repairService = repair.Where(x=>x.IdShip == dto.Id).ToList();
        if (repairService.Count > 0)
        {
            foreach (var item in repairService)
            {
                await _repairRepository.Delete(item.Id,ct);
            }
        }
        var flight = await _flightRepository.GetAllFlights();
        var flightService = flight.Where(x=>x.IdShip == dto.Id).ToList();
        if (flightService.Count > 0)
        {
            foreach (var item in flightService)
            {
                await _flightRepository.Delete(item.Id,ct);
            }
        }
        await _repository.Delete(dto.Id, ct);
        return "Ship deleted";
    }
}