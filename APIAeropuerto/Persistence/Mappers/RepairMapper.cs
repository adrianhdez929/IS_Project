using APIAeropuerto.Application.DTOs.Repair;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Persistence.Entities;
using AutoMapper;
using Microsoft.OpenApi.Extensions;

namespace APIAeropuerto.Persistence.Mappers;

public class RepairMapper : Profile
{
    public RepairMapper()
    {
        CreateMap<RepairEntity, RepairPersistence>();
        CreateMap<RepairPersistence, RepairEntity>();
        CreateMap<RepairPersistence, RepairDTO>()
            .ForMember(dest => dest.IdShip, opt => opt.MapFrom(src => src.IdShip))
            .ForMember(dest => dest.IdService, opt => opt.MapFrom(src => src.IdService))
            .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Service.Code))
            .ForMember(dest => dest.Tuition, opt => opt.MapFrom(src => src.Ship.Tuition));
        CreateMap<RepairDTO, RepairPersistence>();
        CreateMap<RepairEntity, RepairDTO>()
            .ForMember(dest => dest.IdShip, opt => opt.MapFrom(src => src.IdShip))
            .ForMember(dest => dest.IdService, opt => opt.MapFrom(src => src.IdService))
            .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Service.Code))
            .ForMember(dest => dest.Tuition, opt => opt.MapFrom(src => src.Ship.Tuition));
        CreateMap<RepairDTO, RepairEntity>();
        CreateMap<RepairPersistence, GetAllRepairDTO>()
            .ForMember(dest => dest.IdShip, opt => opt.MapFrom(src => src.IdShip))
            .ForMember(dest => dest.IdService, opt => opt.MapFrom(src => src.IdService))
            .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Service.Code))
            .ForMember(dest => dest.Tuition, opt => opt.MapFrom(src => src.Ship.Tuition));
        CreateMap<RepairPersistence, RepairShipDTO>()
            .ForMember(dest => dest.IdService, opt => opt.MapFrom(src => src.IdService))
            .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Service.Code));
    }
}