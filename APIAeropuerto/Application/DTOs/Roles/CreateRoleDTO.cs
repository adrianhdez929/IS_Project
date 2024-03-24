namespace APIAeropuerto.Application.DTOs.Roles;

public class CreateRoleDTO
{
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<string> Claims { get; set; }
}