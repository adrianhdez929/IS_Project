using Microsoft.AspNetCore.Identity;

namespace APIAeropuerto.Persistence.Entities;

public class UserClaimPersistence : IdentityUserClaim<Guid>
{
    public virtual UserPersistence UserPersistence { get; set; }
}