using APIAeropuerto.Application.DTOs.InstallationType;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Persistence.Entities;
using AutoMapper;

namespace APIAeropuerto.Persistence.Mappers;

public class InstallationTypeMapper : Profile
{
    public InstallationTypeMapper()
    {
        CreateMap<InstallationTypePersistence, InstallationTypeDTO>();
        CreateMap<InstallationTypeDTO, InstallationTypePersistence>();
        CreateMap<InstallationTypeEntity, InstallationTypeDTO>();
        CreateMap<InstallationTypeDTO, InstallationTypeEntity>();
        CreateMap<InstallationTypePersistence, GetAllInstallationTypeDTO>();
        CreateMap<GetAllInstallationTypeDTO, InstallationTypePersistence>();
        CreateMap<InstallationTypeEntity, GetAllInstallationTypeDTO>();
        CreateMap<GetAllInstallationTypeDTO, InstallationTypeEntity>();
        CreateMap<InstallationTypePersistence, InstallationTypeEntity>();
        CreateMap<InstallationTypeEntity, InstallationTypePersistence>();
        CreateMap<UpdateInstallationTypeDTO, InstallationTypeEntity>();
        CreateMap<UpdateInstallationTypeDTO, InstallationTypeDTO>();
    }
}