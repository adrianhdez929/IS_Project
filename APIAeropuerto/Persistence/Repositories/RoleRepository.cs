using System.Security.Claims;
using APIAeropuerto.Application.DTOs.Roles;
using APIAeropuerto.Application.DTOs.UserRoles;
using APIAeropuerto.Application.Exceptions.BadRequest;
using APIAeropuerto.Application.Exceptions.NotFound;
using APIAeropuerto.Domain.Interfaces;
using APIAeropuerto.Domain.Shared;
using APIAeropuerto.Persistence.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace APIAeropuerto.Persistence.Repositories;

public class RoleRepository : IRoleRepository
{
    private readonly CoreDbContext _context;
    private readonly RoleManager<RolePersistence> _roleManager;
    private readonly UserManager<UserPersistence> _userManager;
    public RoleRepository(CoreDbContext context, RoleManager<RolePersistence> roleManager, UserManager<UserPersistence> userManager)
    {
        _context = context;
        _roleManager = roleManager;
        _userManager = userManager;
    }
    public async Task<RolePersistence> Update(UpdateRoleDTO dto, CancellationToken cancellationToken)
    {
        var role = await _roleManager.FindByIdAsync(dto.Id.ToString());
        if (role is null) throw new NotFoundException("Role not found");
        var existRole = await _roleManager.FindByNameAsync(dto.Name);
        existRole = existRole?.Id == dto.Id ? null : existRole;
        if (existRole != null) throw new RepeatBadRequestException("Role already exist");
        foreach (var claim in dto.Claims)
            if (!ClaimsStrings.BasePermissions.Contains(claim)) throw new InvalidClaimBadRequestException($"Invalid claim {claim}");
        await using var transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
        try
        {
            role.Name = dto.Name;
            role.Description = dto.Description;
            await _roleManager.UpdateAsync(role);
            var requestClaims = dto.Claims;
            var existingClaims = await _roleManager.GetClaimsAsync(role);
            var claimsToRemove = existingClaims.Where(c => !requestClaims.Contains(c.Value)).ToList();
            var claimsToAdd = requestClaims.Where(c => !existingClaims.Any(ec => ec.Value == c)).ToList();
            var userRoles = await _context.UserRoles.Where(ur => ur.RoleId == role.Id).ToListAsync(cancellationToken);
            foreach (var claim in claimsToRemove)
            {
                var removeResult = await _roleManager.RemoveClaimAsync(role, claim);
                if(!removeResult.Succeeded) await transaction.RollbackAsync(cancellationToken);
            }
            foreach (var claim in claimsToAdd)
            {
                var result = await _roleManager.AddClaimAsync(role, new Claim("Auth", claim));
                if(!result.Succeeded) await transaction.RollbackAsync(cancellationToken);
            }
            foreach (var userRole in userRoles)
            {
                var user = await _userManager.FindByIdAsync(userRole.UserId.ToString());
                if (user is null) throw new NotFoundException("User not found");
                var userClaims = await _userManager.GetClaimsAsync(user);
                var userRoleClaims = await _roleManager.GetClaimsAsync(role);
                var claimsToRemoveUser = userClaims.Where(c => !userRoleClaims.Any(rc => rc.Value == c.Value)).ToList();
                var claimsToAddUser = userRoleClaims.Where(c => !userClaims.Any(uc => uc.Value == c.Value)).ToList();
                foreach (var claim in claimsToRemoveUser)
                {
                    var removeResult = await _userManager.RemoveClaimAsync(user, claim);
                    if(!removeResult.Succeeded) await transaction.RollbackAsync(cancellationToken);
                }
                foreach (var claim in claimsToAddUser)
                {
                    var result = await _userManager.AddClaimAsync(user, new Claim(claim.Type, claim.Value));
                    if(!result.Succeeded) await transaction.RollbackAsync(cancellationToken);
                }
            }
            await transaction.CommitAsync(cancellationToken);
            return role;
        }
        catch (Exception e)
        {
            await transaction.RollbackAsync(cancellationToken);
            throw new Exception(e.Message);
        }
    }

    public async Task<string> AddRolesToUser(AddRolesToUserDTO dto, CancellationToken ct = default)
    {
        var user = await _userManager.FindByIdAsync(dto.UserId.ToString());
        if (user == null) throw new NotFoundException("User not found");
        var roles = await _roleManager.Roles.Where(r => dto.RoleIds.Contains(r.Id)).ToListAsync();
        if (roles.Count != dto.RoleIds.Count) throw new NotFoundException("Role not found");
        foreach (var role in roles)
        {
            var roleClaims = await _roleManager.GetClaimsAsync(role);
            role.RoleClaims = roleClaims.Select(c => new RoleClaimPersistence
            {
                ClaimType = c.Type,
                ClaimValue = c.Value
            }).ToList();
        }
        await using var transaction = await _context.Database.BeginTransactionAsync(ct);
        try
        {
            var result = await _userManager.AddToRolesAsync(user, roles.Select(r => r.Name));
            if (!result.Succeeded) await transaction.RollbackAsync(ct);
            var resultClaims = await _userManager.AddClaimsAsync(user, roles.SelectMany(r => r.RoleClaims.Select(c => new Claim(c.ClaimType!, c.ClaimValue!))));
            if (!resultClaims.Succeeded) await transaction.RollbackAsync(ct);
            await transaction.CommitAsync(ct);
            return "Roles added successfully";
        }
        catch (Exception e)
        {
            await transaction.RollbackAsync(ct);
            throw new Exception(e.Message);
        }
    }
}