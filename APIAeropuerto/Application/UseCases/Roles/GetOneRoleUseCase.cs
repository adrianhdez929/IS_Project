using APIAeropuerto.Application.DTOs.Roles;
using APIAeropuerto.Application.Exceptions.NotFound;
using APIAeropuerto.Domain.Interfaces;
using APIAeropuerto.Persistence.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace APIAeropuerto.Application.UseCases.Roles;

public class GetOneRoleUseCase : IUseCase<RoleDTO,GetOneRoleDTO>
{
    private readonly RoleManager<RolePersistence> _roleManager;
    private readonly IMapper _mapper;
    public GetOneRoleUseCase(RoleManager<RolePersistence> roleManager, IMapper mapper)
    {
        _roleManager = roleManager;
        _mapper = mapper;
    }
    public async Task<RoleDTO> Execute(GetOneRoleDTO dto, CancellationToken ct = default)
    {
        var role = await _roleManager.FindByIdAsync(dto.Id.ToString());
        if (role is null) throw new NotFoundException("Role not found");
        return _mapper.Map<RoleDTO>(role);
    }
}