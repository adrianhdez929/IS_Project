using APIAeropuerto.Application.DTOs.ClientService;
using APIAeropuerto.Application.DTOs.Services;
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
        CreateMap<ClientServicesPersistence, ClientServicesDTO>()
            .ForMember(x => x.Type, y => y.MapFrom(z => z.Service.ServiceType.Type))
            .ForMember(x => x.Code, y => y.MapFrom(z => z.Service.Code))
            .ForMember(x => x.Id, y => y.MapFrom(z => z.IdService))
            .ForMember(x => x.InstallationName, y => y.MapFrom(z => z.Service.Installation.Name))
            .ForMember(x => x.IdInstallations, y => y.MapFrom(z => z.Service.Installation.Id))
            .ForMember(x => x.Description, y => y.MapFrom(z => z.Service.Description))
            .ForMember(x => x.Price, y => y.MapFrom(z => z.Service.Price));
    }
}