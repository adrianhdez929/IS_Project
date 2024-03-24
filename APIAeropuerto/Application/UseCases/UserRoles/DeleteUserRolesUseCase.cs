using APIAeropuerto.Application.DTOs.UserRoles;
using APIAeropuerto.Domain.Interfaces;
using APIAeropuerto.Persistence.Entities;
using Microsoft.AspNetCore.Identity;

namespace APIAeropuerto.Application.UseCases.UserRoles;

public class DeleteUserRolesUseCase : IUseCase<string,DeleteUserRolesDTO>
{
    private readonly UserManager<UserPersistence> _userManager;
    public DeleteUserRolesUseCase(UserManager<UserPersistence> userManager)
    {
        _userManager = userManager;
    }
    public async Task<string> Execute(DeleteUserRolesDTO dto, CancellationToken ct = default)
    {
        var user = await _userManager.FindByIdAsync(dto.Id.ToString());
        if (user is null) throw new Exception("User not found");
        var roles = await _userManager.GetRolesAsync(user);
        foreach (var role in roles)
        {
            await _userManager.RemoveFromRoleAsync(user, role);
        }
        return "User roles deleted";
    }
}