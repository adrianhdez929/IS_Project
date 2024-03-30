using APIAeropuerto.Application.DTOs.Flight;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Persistence.Entities;
using AutoMapper;
using Microsoft.OpenApi.Extensions;

namespace APIAeropuerto.Persistence.Mappers;

public class FlightMapper : Profile
{
    public FlightMapper()
    {
        CreateMap<FlightEntity, FlightPersistence>();
        CreateMap<FlightPersistence, FlightEntity>();
        CreateMap<FlightDTO,FlightPersistence>();
        CreateMap<FlightPersistence, FlightDTO>()
            .ForMember(x => x.Ship, opt => opt.MapFrom(src => src.Ship))
            .ForMember(x => x.Origin, opt => opt.MapFrom(src => src.AirportOrigin))
            .ForMember(x => x.Destination, opt => opt.MapFrom(src => src.AirportDestination))
            .ForMember(x => x.ArrivedClientType, opt => opt.MapFrom(src => src.ArrivedClientType.GetDisplayName()));
        CreateMap<FlightEntity, FlightDTO>();
        CreateMap<FlightDTO, FlightEntity>();
        CreateMap<FlightPersistence, GetAllFlightDTO>()
            .ForMember(x => x.Ship, opt => opt.MapFrom(src => src.Ship))
            .ForMember(x => x.Origin, opt => opt.MapFrom(src => src.AirportOrigin))
            .ForMember(x => x.Destination, opt => opt.MapFrom(src => src.AirportDestination))
            .ForMember(x => x.ArrivedClientType, opt => opt.MapFrom(src => src.ArrivedClientType.GetDisplayName()));
        CreateMap<GetAllFlightDTO, FlightPersistence>();
        CreateMap<FlightEntity, GetAllFlightDTO>()
            .ForMember(x => x.Ship, opt => opt.MapFrom(src => src.Ship))
            .ForMember(x => x.Origin, opt => opt.MapFrom(src => src.AirportOrigin))
            .ForMember(x => x.Destination, opt => opt.MapFrom(src => src.AirportDestination))
            .ForMember(x => x.ArrivedClientType, opt => opt.MapFrom(src => src.ArrivedClientType.GetDisplayName()));
    }
}