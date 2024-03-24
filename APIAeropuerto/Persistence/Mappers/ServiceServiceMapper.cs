using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Persistence.Entities;
using AutoMapper;

namespace APIAeropuerto.Persistence.Mappers;

public class ServiceServiceMapper : Profile
{
    public ServiceServiceMapper()
    {
        CreateMap<ServiceServiceEntity, ServiceServicePersistence>();
        CreateMap<ServiceServicePersistence, ServiceServiceEntity>();
    }
}