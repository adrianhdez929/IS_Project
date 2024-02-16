using APIAeropuerto.Application.DTOs.Installations;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Persistence.Entities;
using AutoMapper;

namespace APIAeropuerto.Persistence.Mappers;

public class InstallationsMapper:Profile
{
    public InstallationsMapper()
    {
        CreateMap<InstallationsEntity, InstallationsPersistence>();
        CreateMap<InstallationsPersistence, InstallationsEntity>();
        CreateMap<InstallationsPersistence, InstallationDTO>();
        CreateMap<InstallationsEntity, InstallationDTO>();
        CreateMap<CreateInstallationsDTO, InstallationDTO>();
        CreateMap<CreateInstallationsDTO, InstallationsEntity>();
        CreateMap<UpdateInstallationDTO, InstallationsEntity>();
        CreateMap<InstallationsPersistence, GetInstallationServicesDTO>();
    }
}