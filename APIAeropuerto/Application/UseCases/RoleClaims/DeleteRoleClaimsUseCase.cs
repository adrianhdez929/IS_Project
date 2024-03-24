using APIAeropuerto.Application.DTOs.RoleClaims;
using APIAeropuerto.Domain.Interfaces;
using APIAeropuerto.Persistence.Entities;
using Microsoft.AspNetCore.Identity;

namespace APIAeropuerto.Application.UseCases.RoleClaims;

public class DeleteRoleClaimsUseCase : IUseCase<string,DeleteRoleClaimsDTO>
{
    private readonly RoleManager<RolePersistence> _roleManager;
    public DeleteRoleClaimsUseCase(RoleManager<RolePersistence> roleManager)
    {
        _roleManager = roleManager;
    }
    public async Task<string> Execute(DeleteRoleClaimsDTO dto, CancellationToken ct = default)
    {
        var role = await _roleManager.FindByIdAsync(dto.Id.ToString());
        if (role is null) throw new Exception("Role not found");
        var claims = await _roleManager.GetClaimsAsync(role);
        foreach (var claim in claims)
        {
            await _roleManager.RemoveClaimAsync(role, claim);
        }
        return "Role claims deleted";
    }
}