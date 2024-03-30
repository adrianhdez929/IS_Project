using APIAeropuerto.Domain.Entities;

namespace APIAeropuerto.Domain.Interfaces;

public interface IClientTypeRepository
{
    Task<ClientTypeEntity> GetOneClientType(Guid id);
}