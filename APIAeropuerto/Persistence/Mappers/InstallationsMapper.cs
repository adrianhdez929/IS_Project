﻿using APIAeropuerto.Application.DTOs.Installations;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Domain.Enums;
using APIAeropuerto.Persistence.Entities;
using AutoMapper;
using Microsoft.OpenApi.Extensions;

namespace APIAeropuerto.Persistence.Mappers;

public class InstallationsMapper:Profile
{
    public InstallationsMapper()
    {
        CreateMap<InstallationsEntity, InstallationsPersistence>();
        CreateMap<InstallationsPersistence, InstallationsEntity>();
        CreateMap<InstallationsPersistence, InstallationDTO>()
            .ForMember(dest => dest.IdAirport, opt => opt.MapFrom(y => y.Airport.Id))
            .ForMember(dest => dest.NameAirport, opt => opt.MapFrom(x => x.Airport.Name))
            .ForMember(dest => dest.Type, opt => opt.MapFrom(x => x.InstallationType.Type));
        CreateMap<InstallationsEntity, InstallationDTO>()
            .ForMember(dest => dest.IdAirport, opt => opt.MapFrom(y => y.Airport.Id))
            .ForMember(dest => dest.NameAirport, opt => opt.MapFrom(x => x.Airport.Name))
            .ForMember(dest => dest.Type, opt => opt.MapFrom(x =>x.InstallationType.Type));
        CreateMap<CreateInstallationsDTO, InstallationDTO>();
        CreateMap<CreateInstallationsDTO, InstallationsEntity>();
        CreateMap<UpdateInstallationDTO, InstallationsEntity>();
        CreateMap<InstallationsPersistence, GetInstallationServicesDTO>();
        CreateMap<InstallationsEntity, GetAllInstallationsDTO>();
        CreateMap<GetAllInstallationsDTO, InstallationsEntity>();
        CreateMap<InstallationsPersistence, GetAllInstallationsDTO>()
            .ForMember(dest => dest.IdAirport, opt => opt.MapFrom(y => y.Airport.Id))
            .ForMember(dest => dest.NameAirport, opt => opt.MapFrom(x => x.Airport.Name))
            .ForMember(dest => dest.Type, opt => opt.MapFrom(x =>x.InstallationType.Type));
        CreateMap<GetAllInstallationsDTO, InstallationsPersistence>();
        CreateMap<InstallationsEntity , GetOneInstallationDTO>()
            .ForMember(dest => dest.IdAirport, opt => opt.MapFrom(y => y.Airport.Id))
            .ForMember(dest => dest.NameAirport, opt => opt.MapFrom(x => x.Airport.Name))
            .ForMember(dest => dest.Type, opt => opt.MapFrom(x => x.InstallationType.Type))
            .ForMember(dest => dest.Services, opt => opt.MapFrom(x => x.Services));
    }
}