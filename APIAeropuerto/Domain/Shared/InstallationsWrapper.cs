using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Domain.Interfaces;

namespace APIAeropuerto.Domain.Shared;

public class InstallationsWrapper : ISimpleWrapper<InstallationsEntity>
{
    public bool IsSuccess { get; set; }
    public InstallationsEntity Value { get; set; }
    public string ErrorMessage { get; set; }
}