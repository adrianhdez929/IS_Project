using APIAeropuerto.Application.DTOs.Airport;
using APIAeropuerto.Application.UseCases.Airport;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Persistence.Entities;
using AutoMapper;

namespace APIAeropuerto.Persistence.Mappers;
public class AirportMapper : Profile
{
    public AirportMapper()
    {
        CreateMap<AirportEntity, AirportPersistence>();
        CreateMap<AirportPersistence, AirportEntity>();
        CreateMap<AirportPersistence, AirportDTO>();
        CreateMap<AirportEntity, AirportDTO>();
        CreateMap<CreateAirportDTO, AirportDTO>();
        CreateMap<UpdateAirportDTO, AirportEntity>();
        CreateMap<AirportPersistence, GetAirportInstDTO>();
    }
}

