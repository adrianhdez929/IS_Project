using System.Collections;
using APIAeropuerto.Application.DTOs.Repair;
using APIAeropuerto.Application.DTOs.Services;
using APIAeropuerto.Application.DTOs.Ship;

namespace APIAeropuerto.Domain.Interfaces;

public interface IRepairRepository
{
    Task<IEnumerable<RepairShipDTO>> GetAllRepairsShip(Guid idShip);
    Task<RepairDTO> GetOneRepair(Guid id);
    Task<IEnumerable<GetAllRepairDTO>> GetAllRepairs();
    
    Task<IEnumerable<ShipDTO>> GetAllShipsRepair(Guid idRepair);
    
    Task<IEnumerable<ServiceDTO>> GetAllServicesShip(Guid idShip);
}