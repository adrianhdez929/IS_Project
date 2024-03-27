using APIAeropuerto.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace APIAeropuerto.Persistence.Entities;

public class UserPersistence : IdentityUser<Guid>
{
    public DateTime LastLogin { get; set; }
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
    public virtual ClientPersistence Client { get; set; }
    public virtual ICollection<UserRolePersistence> UserRoles { get; set; }
    public virtual ICollection<UserClaimPersistence> UserClaims { get; set; }
    public virtual ICollection<UserLoginPersistence> UserLogins { get; set; }
}