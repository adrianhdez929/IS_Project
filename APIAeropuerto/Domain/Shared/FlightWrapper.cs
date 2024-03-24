using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Domain.Interfaces;

namespace APIAeropuerto.Domain.Shared;

public class FlightWrapper : ISimpleWrapper<FlightEntity>
{
    public bool IsSuccess { get; set; }
    public FlightEntity? Value { get; set; }
    public string? ErrorMessage { get; set; }
}