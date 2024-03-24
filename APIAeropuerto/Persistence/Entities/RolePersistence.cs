using Microsoft.AspNetCore.Identity;

namespace APIAeropuerto.Persistence.Entities;

public class RolePersistence : IdentityRole<Guid>
{
    public virtual ICollection<UserRolePersistence> UserRoles { get; set; }
    public virtual ICollection<RoleClaimPersistence> RoleClaims { get; set; }
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
    public string Description { get; set; }
}