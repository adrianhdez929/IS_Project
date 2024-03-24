using Microsoft.AspNetCore.Identity;

namespace APIAeropuerto.Domain.Entities;

public class UserRoleEntity : IdentityUserRole<Guid>
{
    public virtual UsersEntity UserEntity { get; set; }
    public virtual RoleEntity RoleEntity { get; set; }
}