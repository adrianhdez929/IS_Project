using APIAeropuerto.Application.DTOs.Roles;
using APIAeropuerto.Persistence.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace APIAeropuerto.Application.UseCases.Roles;

public class GetAllRolesUseCase
{
    private readonly RoleManager<RolePersistence> _roleManager;
    private readonly IMapper _mapper;
    public GetAllRolesUseCase(RoleManager<RolePersistence> roleManager, IMapper mapper)
    {
        _roleManager = roleManager;
        _mapper = mapper;
    }
    public async Task<IEnumerable<RoleDTO>> Execute(CancellationToken ct = default)
    {
        var roles = await _roleManager.Roles.ToListAsync();
        return _mapper.Map<IEnumerable<RoleDTO>>(roles);
    }
}