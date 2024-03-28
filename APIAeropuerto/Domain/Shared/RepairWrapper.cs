using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Domain.Interfaces;

namespace APIAeropuerto.Domain.Shared;

public class RepairWrapper : ISimpleWrapper<RepairEntity>
{
    public bool IsSuccess { get; set; }
    public RepairEntity? Value { get; set; }
    public string? ErrorMessage { get; set; }
}