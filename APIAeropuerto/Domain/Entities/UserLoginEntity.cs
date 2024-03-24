using Microsoft.AspNetCore.Identity;

namespace APIAeropuerto.Domain.Entities;

public class UserLoginEntity : IdentityUserLogin<Guid>
{
    public virtual UsersEntity UserEntity { get; set; }
}