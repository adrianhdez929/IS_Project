using Microsoft.AspNetCore.Identity;

namespace APIAeropuerto.Persistence.Entities;

public class RoleClaimPersistence : IdentityRoleClaim<Guid>
{
    public virtual RolePersistence RolePersistence { get; set; }
}