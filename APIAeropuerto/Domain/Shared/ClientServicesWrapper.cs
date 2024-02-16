using APIAeropuerto.Domain.Entities;

namespace APIAeropuerto.Domain.Shared;

public class ClientServicesWrapper
{
    public ClientServicesEntity Value { get; set; }
    public string ErrorMessage { get; set; }
    public bool IsSuccess { get; set; }
}