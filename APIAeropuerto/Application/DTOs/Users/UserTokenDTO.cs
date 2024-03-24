namespace APIAeropuerto.Application.DTOs.Users;

public interface UserTokenDTO
{
    public Guid Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
}