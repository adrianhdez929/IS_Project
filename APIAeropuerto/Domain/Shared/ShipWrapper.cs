using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Domain.Interfaces;

namespace APIAeropuerto.Domain.Shared;

public class ShipWrapper : ISimpleWrapper<ShipEntity>
{
    public bool IsSuccess { get; set; }
    public ShipEntity? Value { get; set; }
    public string? ErrorMessage { get; set; }
}