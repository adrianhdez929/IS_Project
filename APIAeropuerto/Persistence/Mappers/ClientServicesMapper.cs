using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Persistence.Entities;
using AutoMapper;

namespace APIAeropuerto.Persistence.Mappers;

public class ClientServicesMapper : Profile
{
    public ClientServicesMapper()
    {
        CreateMap<ClientServicesEntity, ClientServicesPersistence>();
        CreateMap<ClientServicesPersistence, ClientServicesEntity>();
    }
}