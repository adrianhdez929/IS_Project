using System.Security.Claims;
using APIAeropuerto.Application.DTOs.Roles;
using APIAeropuerto.Application.DTOs.UserRoles;
using APIAeropuerto.Persistence.Entities;

namespace APIAeropuerto.Domain.Interfaces;

public interface IRoleRepository
{
    Task<RolePersistence> Update(UpdateRoleDTO dto, CancellationToken cancellationToken);
    Task<string> AddRolesToUser(AddRolesToUserDTO dto, CancellationToken ct = default);
}