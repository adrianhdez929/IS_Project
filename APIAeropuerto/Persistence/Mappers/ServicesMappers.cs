using APIAeropuerto.Application.DTOs.Services;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Persistence.Entities;
using AutoMapper;

namespace APIAeropuerto.Persistence.Mappers;

public class ServicesMappers : Profile
{
    public ServicesMappers()
    {
        CreateMap<ServicesEntity, ServicesPersistence>();
        CreateMap<ServicesPersistence, ServicesEntity>();
        CreateMap<ServicesPersistence, ServiceDTO>();
        CreateMap<ServicesEntity, ServiceDTO>();
        CreateMap<CreateServiceDTO, ServiceDTO>();
        CreateMap<CreateServiceDTO, ServicesEntity>();
        CreateMap<UpdateServiceDTO, ServicesEntity>();
        CreateMap<List<ClientPersistence>, GetAllClientsServiceDTO>();
        CreateMap<ServicesPersistence, GetAllClientsServiceDTO>();
    }
}