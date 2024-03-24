using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Domain.Interfaces;

namespace APIAeropuerto.Domain.Shared;

public class ClientWrapper : ISimpleWrapper<ClientEntity>
{
    public bool IsSuccess { get; set; }
    public ClientEntity? Value { get; set; }
    public string? ErrorMessage { get; set; }
}