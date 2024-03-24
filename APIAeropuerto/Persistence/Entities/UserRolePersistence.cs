using Microsoft.AspNetCore.Identity;

namespace APIAeropuerto.Persistence.Entities;

public class UserRolePersistence : IdentityUserRole<Guid>
{
    public virtual UserPersistence UserPersistence { get; set; }
    public virtual RolePersistence RolePersistence { get; set; }
}