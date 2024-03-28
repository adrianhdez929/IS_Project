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
        CreateMap<InstallationsPersistence, InstallationDTO>()
            .ForMember(dest => dest.IdAirport, opt => opt.MapFrom(y => y.Airport.Id))
            .ForMember(dest => dest.NameAirport, opt => opt.MapFrom(x => x.Airport.Name));
        CreateMap<InstallationsEntity, InstallationDTO>()
            .ForMember(dest => dest.IdAirport, opt => opt.MapFrom(y => y.Airport.Id))
            .ForMember(dest => dest.NameAirport, opt => opt.MapFrom(x => x.Airport.Name));
        CreateMap<CreateInstallationsDTO, InstallationDTO>();
        CreateMap<CreateInstallationsDTO, InstallationsEntity>();
        CreateMap<UpdateInstallationDTO, InstallationsEntity>();
        CreateMap<InstallationsPersistence, GetInstallationServicesDTO>();
        CreateMap<InstallationsEntity, GetAllInstallationsDTO>();
        CreateMap<GetAllInstallationsDTO, InstallationsEntity>();
        CreateMap<InstallationsPersistence, GetAllInstallationsDTO>()
            .ForMember(dest => dest.IdAirport, opt => opt.MapFrom(y => y.Airport.Id))
            .ForMember(dest => dest.NameAirport, opt => opt.MapFrom(x => x.Airport.Name));
        CreateMap<GetAllInstallationsDTO, InstallationsPersistence>();
        CreateMap<InstallationsEntity , GetOneInstallationDTO>()
            .ForMember(dest => dest.IdAirport, opt => opt.MapFrom(y => y.Airport.Id))
            .ForMember(dest => dest.NameAirport, opt => opt.MapFrom(x => x.Airport.Name))
            .ForMember(dest => dest.Services, opt => opt.MapFrom(x => x.Services));
    }
}