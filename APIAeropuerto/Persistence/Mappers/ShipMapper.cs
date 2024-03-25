using APIAeropuerto.Application.DTOs.Ship;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Persistence.Entities;
using AutoMapper;


namespace APIAeropuerto.Persistence.Mappers;

public class ShipMapper : Profile
{
    public ShipMapper()
    {
        CreateMap<ShipEntity, ShipPersistence>();
        CreateMap<ShipPersistence, ShipEntity>();
        CreateMap<ShipPersistence, ShipDTO>()
            .ForMember(x=>x.PropietaryName, y=>y.MapFrom(z=>z.Propietary.Name));
        CreateMap<ShipEntity, ShipDTO>();
        CreateMap<UpdateShipDTO, ShipEntity>();
        CreateMap<ShipPersistence, GetAllShipDTO>();
        CreateMap<GetAllShipDTO, ShipPersistence>();
    }
}