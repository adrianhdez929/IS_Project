using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Domain.Interfaces;

namespace APIAeropuerto.Domain.Shared;

public class RoleWrapper : ISimpleWrapper<RoleEntity>
{
    public bool IsSuccess { get; set; }
    public RoleEntity? Value { get; set; }
    public string? ErrorMessage { get; set; }
}