using APIAeropuerto.Application.DTOs.Users;

namespace APIAeropuerto.Domain.Interfaces;

public interface IUserRepository
{
    Task<UsersDTO> CreateUser(CreateUserDTO dto, CancellationToken ct = default);
    Task<Guid> FindClientByUser(Guid idUser, CancellationToken ct = default);
}