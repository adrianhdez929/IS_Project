using APIAeropuerto.Application.DTOs.Client;

namespace APIAeropuerto.Application.DTOs.Users;

public class CreateUserDTO : CreateClientDTO
{
    public string UserName { get; set; }
    public string PasswordHash { get; set; }
    public string Email { get; set; }
}