using System.Security.Claims;
using APIAeropuerto.Application.DTOs.RoleClaims;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Persistence.Entities;
using AutoMapper;

namespace APIAeropuerto.Persistence.Mappers;

public class RoleClaimsMapper : Profile
{
    public RoleClaimsMapper()
    {
        CreateMap<RoleClaimEntity, RoleClaimPersistence>();
        CreateMap<RoleClaimPersistence, RoleClaimEntity>();
        CreateMap<Claim, RoleClaimsDTO>()
            .ForMember(x => x.ClaimType, y => y.MapFrom(z => z.Type))
            .ForMember(x => x.ClaimValue, y => y.MapFrom(z => z.Value));
    }
}