using Microsoft.AspNetCore.Identity;

namespace APIAeropuerto.Domain.Entities;

public class RoleClaimEntity : IdentityRoleClaim<Guid>
{
    public virtual RoleEntity RoleEntity { get; set; }
}