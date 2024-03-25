using APIAeropuerto.Application.DTOs.Users;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Persistence.Entities;
using AutoMapper;

namespace APIAeropuerto.Persistence.Mappers;

public class UsersMapper : Profile
{
    public UsersMapper()
    {
        CreateMap<UsersEntity, UserPersistence>();
        CreateMap<UserPersistence, UsersEntity>();
        CreateMap<UserPersistence, UsersDTO>();
        CreateMap<UsersEntity, UsersDTO>();
        CreateMap<CreateUserDTO, UsersDTO>();
        CreateMap<CreateUserDTO, UsersEntity>();
        CreateMap<UpdateUserDTO, UsersEntity>();
        CreateMap<UserPersistence, GetAllUsersDTO>();
    }
}