using APIAeropuerto.Application.DTOs.Client;
using APIAeropuerto.Application.DTOs.Installations;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Persistence.Entities;
using AutoMapper;
using Microsoft.OpenApi.Extensions;

namespace APIAeropuerto.Persistence.Mappers;

public class ClientMapper : Profile
{
    public ClientMapper()
    {
        CreateMap<ClientEntity, ClientPersistence>();
        CreateMap<ClientPersistence, ClientEntity>();
        CreateMap<ClientPersistence, ClientDTO>()
            .ForMember(dest => dest.Type, opt => opt.MapFrom(x => x.Type.GetDisplayName()));
        CreateMap<ClientEntity, ClientDTO>()
            .ForMember(dest => dest.Type, opt => opt.MapFrom(x => x.Type.GetDisplayName()));
        CreateMap<CreateClientDTO, ClientDTO>();
        CreateMap<CreateClientDTO, ClientEntity>();
        CreateMap<UpdateInstallationDTO, ClientEntity>();
        CreateMap<List<ServicesPersistence>, GetlAllServicesClientDTO>();
        CreateMap<ClientServicesEntity, ClientServicesPersistence>();
        CreateMap<GetAllClientDTO, ClientEntity>();
        CreateMap<ClientEntity, GetAllClientDTO>()
            .ForMember(dest => dest.Type, opt => opt.MapFrom(x => x.Type.GetDisplayName()));
        CreateMap<ClientPersistence, GetAllClientDTO>()
            .ForMember(dest => dest.Type, opt => opt.MapFrom(x => x.Type.GetDisplayName()));
        CreateMap<GetAllClientDTO, ClientPersistence>();
    }
}