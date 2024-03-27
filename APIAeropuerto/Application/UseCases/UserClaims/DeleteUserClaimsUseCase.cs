using APIAeropuerto.Application.DTOs.UserClaims;
using APIAeropuerto.Application.Exceptions.NotFound;
using APIAeropuerto.Domain.Interfaces;
using APIAeropuerto.Persistence.Entities;
using Microsoft.AspNetCore.Identity;

namespace APIAeropuerto.Application.UseCases.UserClaims;

public class DeleteUserClaimsUseCase : IUseCase<string,DeleteUserClaimsDTO>
{
    private readonly UserManager<UserPersistence> _userManager;
    public DeleteUserClaimsUseCase(UserManager<UserPersistence> userManager)
    {
        _userManager = userManager;
    }
    public async Task<string> Execute(DeleteUserClaimsDTO dto, CancellationToken ct = default)
    {
        var user = await _userManager.FindByIdAsync(dto.Id.ToString());
        if (user is null) throw new NotFoundException("User not found");
        var claims = await _userManager.GetClaimsAsync(user);
        foreach (var claim in claims)
        {
            await _userManager.RemoveClaimAsync(user, claim);
        }
        return "User claims deleted";
    }
}