using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Domain.Interfaces;

namespace APIAeropuerto.Domain.Shared;

public class ServicesWrapper : ISimpleWrapper<ServicesEntity>
{
    public bool IsSuccess { get; set; }
    public ServicesEntity? Value { get; set; }
    public string? ErrorMessage { get; set; }
}