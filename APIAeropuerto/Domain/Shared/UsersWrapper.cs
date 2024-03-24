using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Domain.Interfaces;

namespace APIAeropuerto.Domain.Shared;

public class UsersWrapper : ISimpleWrapper<UsersEntity>
{
    public bool IsSuccess { get; set; }
    public UsersEntity? Value { get; set; }
    public string? ErrorMessage { get; set; }
}