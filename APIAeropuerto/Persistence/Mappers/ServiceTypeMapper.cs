using APIAeropuerto.Application.DTOs.ServiceType;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Persistence.Entities;
using AutoMapper;

namespace APIAeropuerto.Persistence.Mappers;

public class ServiceTypeMapper : Profile
{
    public ServiceTypeMapper()
    {
        CreateMap<ServiceTypePersistence, ServiceTypeDTO>();
        CreateMap<ServiceTypeDTO, ServiceTypePersistence>();
        CreateMap<ServiceTypeEntity, ServiceTypeDTO>();
        CreateMap<ServiceTypeDTO, ServiceTypeEntity>();
        CreateMap<ServiceTypePersistence, GetAllServiceTypeDTO>();
        CreateMap<GetAllServiceTypeDTO, ServiceTypePersistence>();
        CreateMap<ServiceTypeEntity, GetAllServiceTypeDTO>();
        CreateMap<GetAllServiceTypeDTO, ServiceTypeEntity>();
        CreateMap<ServiceTypePersistence, ServiceTypeEntity>();
        CreateMap<ServiceTypeEntity, ServiceTypePersistence>();
        CreateMap<UpdateServiceTypeDTO, ServiceTypeEntity>();
        CreateMap<UpdateServiceTypeDTO, ServiceTypeDTO>();
    }
}