namespace APIAeropuerto.Application.DTOs.Users;

public class CreateUserDTO
{
    public string UserName { get; set; }
    public string PasswordHash { get; set; }
    public string Email { get; set; }
}