namespace APIAeropuerto.Application.DTOs.UserRoles;

public class AddRolesToUserDTO
{
    public Guid UserId { get; set; }
    public List<Guid> RoleIds { get; set; }
}