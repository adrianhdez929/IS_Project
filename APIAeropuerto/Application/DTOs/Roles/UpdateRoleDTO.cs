namespace APIAeropuerto.Application.DTOs.Roles;

public class UpdateRoleDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public ICollection<string> Claims { get; set; }
}