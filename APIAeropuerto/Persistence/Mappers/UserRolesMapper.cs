using System.Security.Claims;
using APIAeropuerto.Application.DTOs.UserRoles;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Persistence.Entities;
using AutoMapper;

namespace APIAeropuerto.Persistence.Mappers;

public class UserRolesMapper : Profile
{
    public UserRolesMapper()
    {
        CreateMap<UserRoleEntity, UserRolePersistence>();
        CreateMap<UserRolePersistence, UserRoleEntity>();
        CreateMap<Claim, UserRolesDTO>();
        CreateMap<string, UserRolesDTO>()
            .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src));
    }
}