using APIAeropuerto.Application.DTOs.Roles;
using APIAeropuerto.Application.Exceptions.NotFound;
using APIAeropuerto.Domain.Interfaces;
using APIAeropuerto.Persistence.Entities;
using Microsoft.AspNetCore.Identity;

namespace APIAeropuerto.Application.UseCases.Roles;

public class DeleteRoleUseCase : IUseCase<string,DeleteRoleDTO>
{
    private readonly RoleManager<RolePersistence> _roleManager;
    public DeleteRoleUseCase(RoleManager<RolePersistence> roleManager)
    {
        _roleManager = roleManager;
    }
    public async Task<string> Execute(DeleteRoleDTO dto, CancellationToken ct = default)
    {
        var role = await _roleManager.FindByIdAsync(dto.Id.ToString());
        if (role is null) throw new NotFoundException("Role not found"); 
        var result = await _roleManager.DeleteAsync(role);
        if (result.Succeeded) return"Role deleted";
        return "Error deleting role";
    }
}