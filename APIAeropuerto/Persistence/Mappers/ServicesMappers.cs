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
        CreateMap<ServicesEntity, ServicesPersistence>()
            .ForMember(x => x.Installation, opt => opt.MapFrom(x => x.Installation))
            .ForMember(x => x.ServiceType, opt => opt.MapFrom(x => x.ServiceTypeEntity));
        CreateMap<ServicesPersistence, ServicesEntity>()
            .ForMember(x => x.ServiceTypeEntity, opt => opt.MapFrom(x => x.ServiceType));
        CreateMap<ServicesPersistence, ServiceDTO>();
        CreateMap<ServicesEntity, ServiceDTO>()
            .ForMember(dest => dest.IdInstallations, opt => opt.MapFrom(x => x.Installation.Id))
            .ForMember(dest => dest.InstallationName, opt => opt.MapFrom(x => x.Installation.Name))
            .ForMember(dest => dest.Type, opt => opt.MapFrom(x => x.ServiceTypeEntity.Type));
        CreateMap<CreateServiceDTO, ServiceDTO>();
        CreateMap<CreateServiceDTO, ServicesEntity>();
        CreateMap<UpdateServiceDTO, ServicesEntity>();
        CreateMap<List<ClientPersistence>, GetAllClientsServiceDTO>();
        CreateMap<ServicesPersistence, GetAllClientsServiceDTO>();
        CreateMap<ServicesEntity, GetAllServicesDTO>()
            .ForMember(dest => dest.IdInstallations, opt => opt.MapFrom(x => x.Installation.Id))
            .ForMember(dest => dest.InstallationName, opt => opt.MapFrom(x => x.Installation.Name))
            .ForMember(dest => dest.Type, opt => opt.MapFrom(x => x.ServiceTypeEntity.Type));
        CreateMap<ServicesPersistence, GetAllServicesDTO>()
            .ForMember(dest => dest.IdInstallations, opt => opt.MapFrom(x => x.Installation.Id))
            .ForMember(dest => dest.InstallationName, opt => opt.MapFrom(x => x.Installation.Name))
            .ForMember(dest => dest.Type, opt => opt.MapFrom(x => x.ServiceType.Type));
        CreateMap<GetAllServicesDTO, ServicesPersistence>();
    }
}