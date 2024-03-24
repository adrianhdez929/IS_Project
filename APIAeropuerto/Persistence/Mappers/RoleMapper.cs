using APIAeropuerto.Application.DTOs.Roles;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Persistence.Entities;
using AutoMapper;

namespace APIAeropuerto.Persistence.Mappers;

public class RoleMapper : Profile
{
    public RoleMapper()
    {
        CreateMap<RoleEntity, RolePersistence>();
        CreateMap<RolePersistence, RoleEntity>();
        CreateMap<RolePersistence, RoleDTO>();
        CreateMap<RoleEntity, RoleDTO>();
        CreateMap<CreateRoleDTO, RoleDTO>();
        CreateMap<CreateRoleDTO, RolePersistence>();
        CreateMap<UpdateRoleDTO, RoleEntity>();
    }
}