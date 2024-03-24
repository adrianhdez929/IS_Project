namespace APIAeropuerto.Application.DTOs.Users;

public class UpdateUserDTO
{
    public Guid Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}