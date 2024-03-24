using System.Security.Claims;
using APIAeropuerto.Application.DTOs.Roles;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Domain.Interfaces;
using APIAeropuerto.Domain.Shared;
using APIAeropuerto.Persistence.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace APIAeropuerto.Application.UseCases.Roles;

public class CreateRoleUseCase : IUseCase<RoleDTO,CreateRoleDTO>
{
    public readonly RoleManager<RolePersistence> _roleManager;
    public readonly IMapper _mapper;
    
    public CreateRoleUseCase(RoleManager<RolePersistence> roleManager, IMapper mapper)
    {
        _roleManager = roleManager;
        _mapper = mapper;
    }
    public async Task<RoleDTO> Execute(CreateRoleDTO dto, CancellationToken ct = default)
    {
        foreach (var claim in dto.Claims)
            if (!ClaimsStrings.BasePermissions.Contains(claim)) throw new Exception($"Invalid claim {claim}");
        var role = RoleEntity.Create(dto.Name, dto.Description);
        if(!role.IsSuccess) throw new Exception(role.ErrorMessage);
        var roleExists = await _roleManager.FindByNameAsync(dto.Name);
        if(roleExists is not null) throw new Exception("Role already exists");
        var roleMapper = _mapper.Map<RolePersistence>(role.Value);
        var result = await _roleManager.CreateAsync(roleMapper);
        if (result.Succeeded)
        {
            foreach (var claim in dto.Claims)
            {
                await _roleManager.AddClaimAsync(roleMapper, new Claim("Auth",claim));
            }
            return _mapper.Map<RoleDTO>(roleMapper);
        }

        throw new Exception(result.Errors.First().Description);
    }
}