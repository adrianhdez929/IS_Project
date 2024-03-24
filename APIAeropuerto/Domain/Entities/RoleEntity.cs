using APIAeropuerto.Domain.Shared;
using Microsoft.AspNetCore.Identity;

namespace APIAeropuerto.Domain.Entities;

public class RoleEntity : IdentityRole<Guid>
{
    public string Description { get; set; }
    public DateTime Created { get; set; }
    public DateTime Updated { get; set; }
    public virtual ICollection<UserRoleEntity> UserRoles { get; set; }
    public virtual ICollection<RoleClaimEntity> RoleClaims { get; set; }
    
    public RoleEntity(string name, string description)
    {
        Name = name;
        Description = description;
        Created = DateTime.Now;
        Updated = DateTime.Now;
    }
    public static RoleWrapper Create(string name, string description)
    {
        var role = new RoleEntity(name, description);
        return new RoleWrapper
        {
            IsSuccess = true,
            ErrorMessage = string.Empty,
            Value = role
        };
    }
    
    public void Update(string name, string description)
    {
        Name = name;
        Description = description;
        Updated = DateTime.Now;
    }
}