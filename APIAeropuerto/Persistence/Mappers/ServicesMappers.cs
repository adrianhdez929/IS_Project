using APIAeropuerto.Application.DTOs.Services;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Persistence.Entities;
using AutoMapper;
using Microsoft.OpenApi.Extensions;

namespace APIAeropuerto.Persistence.Mappers;

public class ServicesMappers : Profile
{
    public ServicesMappers()
    {
        CreateMap<ServicesEntity, ServicesPersistence>();
        CreateMap<ServicesPersistence, ServicesEntity>();
        CreateMap<ServicesPersistence, ServiceDTO>();
        CreateMap<ServicesEntity, ServiceDTO>()
            .ForMember(dest => dest.Type, opt => opt.MapFrom(x => x.ServiceType.GetDisplayName()));
        CreateMap<CreateServiceDTO, ServiceDTO>();
        CreateMap<CreateServiceDTO, ServicesEntity>();
        CreateMap<UpdateServiceDTO, ServicesEntity>();
        CreateMap<List<ClientPersistence>, GetAllClientsServiceDTO>();
        CreateMap<ServicesPersistence, GetAllClientsServiceDTO>();
        CreateMap<ServicesEntity, GetAllServicesDTO>();
        CreateMap<GetAllServicesDTO, ServicesEntity>();
        CreateMap<ServicesPersistence, GetAllServicesDTO>();
        CreateMap<GetAllServicesDTO, ServicesPersistence>();
    }
}