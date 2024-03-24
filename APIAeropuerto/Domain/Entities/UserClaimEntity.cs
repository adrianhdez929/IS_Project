using Microsoft.AspNetCore.Identity;

namespace APIAeropuerto.Domain.Entities;

public class UserClaimEntity : IdentityUserClaim<Guid>
{
    public virtual UsersEntity UserEntity { get; set; }
}