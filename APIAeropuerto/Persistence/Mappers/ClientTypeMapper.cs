using APIAeropuerto.Application.DTOs.ClientType;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Persistence.Entities;
using AutoMapper;

namespace APIAeropuerto.Persistence.Mappers;

public class ClientTypeMapper : Profile
{
    public ClientTypeMapper()
    {
        CreateMap<ClientTypePersistence, ClientTypeDTO>();
        CreateMap<ClientTypeDTO, ClientTypePersistence>();
        CreateMap<ClientTypeEntity, ClientTypeDTO>();
        CreateMap<ClientTypeDTO, ClientTypeEntity>();
        CreateMap<ClientTypePersistence, GetAllClientTypeDTO>();
        CreateMap<GetAllClientTypeDTO, ClientTypePersistence>();
        CreateMap<ClientTypeEntity, GetAllClientTypeDTO>();
        CreateMap<GetAllClientTypeDTO, ClientTypeEntity>();
        CreateMap<ClientTypePersistence, ClientTypeEntity>();
        CreateMap<ClientTypeEntity, ClientTypePersistence>();
        CreateMap<UpdateClientTypeDTO, ClientTypeEntity>();
        CreateMap<UpdateClientTypeDTO, ClientTypeDTO>();
    }
}