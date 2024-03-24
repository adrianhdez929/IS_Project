using System.Security.Claims;
using APIAeropuerto.Application.DTOs.UserClaims;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Persistence.Entities;
using AutoMapper;

namespace APIAeropuerto.Persistence.Mappers;

public class UserClaimsMapper : Profile
{
    public UserClaimsMapper()
    {
        CreateMap<UserClaimEntity, UserClaimPersistence>();
        CreateMap<UserClaimPersistence, UserClaimEntity>();
        CreateMap<Claim, UserClaimsDTO>()
            .ForMember(x => x.ClaimType, opt => opt.MapFrom(src => src.Type))
            .ForMember(x => x.ClaimValue, opt => opt.MapFrom(src => src.Value));
        
    }
}