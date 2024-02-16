using APIAeropuerto.Application.DTOs.Client;
using APIAeropuerto.Application.DTOs.Installations;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Persistence.Entities;
using AutoMapper;

namespace APIAeropuerto.Persistence.Mappers;

public class ClientMapper : Profile
{
    public ClientMapper()
    {
        CreateMap<ClientEntity, ClientPersistence>();
        CreateMap<ClientPersistence, ClientEntity>();
        CreateMap<ClientPersistence, ClientDTO>();
        CreateMap<ClientEntity, ClientDTO>();
        CreateMap<CreateClientDTO, ClientDTO>();
        CreateMap<CreateClientDTO, ClientEntity>();
        CreateMap<UpdateInstallationDTO, ClientEntity>();
        CreateMap<List<ServicesPersistence>, GetlAllServicesClientDTO>();
        CreateMap<ClientServicesEntity, ClientServicesPersistence>();
    }
}