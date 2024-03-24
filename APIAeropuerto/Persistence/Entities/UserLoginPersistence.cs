using Microsoft.AspNetCore.Identity;

namespace APIAeropuerto.Persistence.Entities;

public class UserLoginPersistence : IdentityUserLogin<Guid>
{
    public virtual UserPersistence UserPersistence { get; set; }
}