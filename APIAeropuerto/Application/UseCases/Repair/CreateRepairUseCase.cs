using APIAeropuerto.Application.DTOs.Repair;
using APIAeropuerto.Application.Exceptions.BadRequest;
using APIAeropuerto.Application.Exceptions.NotFound;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Domain.Interfaces;
using APIAeropuerto.Persistence.Repositories;
using AutoMapper;

namespace APIAeropuerto.Application.UseCases.Repair;

public class CreateRepairUseCase : IUseCase<RepairDTO,CreateRepairDTO>
{
    private readonly IServiceRepository _serviceRepository;
    private readonly IBaseRepository<ShipEntity> _shipRepository;
    private readonly RepairRepository _repairRepository;
    private readonly IMapper _mapper;
    
    public CreateRepairUseCase(IServiceRepository serviceRepository, IBaseRepository<ShipEntity> shipRepository, RepairRepository repairRepository, IMapper mapper)
    {
        _serviceRepository = serviceRepository;
        _shipRepository = shipRepository;
        _repairRepository = repairRepository;
        _mapper = mapper;
    }
    public async Task<RepairDTO> Execute(CreateRepairDTO dto, CancellationToken ct = default)
    {
        var service = await _serviceRepository.GetOneService(dto.IdService);
        if (service is null) throw new NotFoundException("Service not found");
        var ship = await _shipRepository.GetOne(dto.IdShip,ct);
        if (ship is null) throw new NotFoundException("Ship not found");
        var price = service.Price;
        var shipRepairs = await _repairRepository.GetAllRepairsShip(dto.IdShip);
        var repair = RepairEntity.CreateWrapper(dto.Rating, dto.Comment,price, dto.DateInit, dto.DateEnd, dto.DateEstimated,!shipRepairs.Any());
        if(!repair.IsSuccess) throw new CreateRepairBadRequestException("Error creating repair");
        repair.Value!.IdShip = dto.IdShip;
        repair.Value!.IdService = dto.IdService;
        await _repairRepository.Create(repair.Value, ct);
        repair.Value!.Service = service;
        repair.Value!.Ship = ship;
        return _mapper.Map<RepairDTO>(repair.Value);
    }
}