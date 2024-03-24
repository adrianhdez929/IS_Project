using APIAeropuerto.Application.DTOs.Roles;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Domain.Interfaces;
using APIAeropuerto.Persistence.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace APIAeropuerto.Application.UseCases.Roles;

public class UpdateRoleUseCase : IUseCase<RoleDTO,UpdateRoleDTO>
{
    private readonly IRoleRepository _roleRepository;
    private readonly IMapper _mapper;
    public UpdateRoleUseCase(IRoleRepository roleRepository, IMapper mapper)
    {
        _roleRepository = roleRepository;
        _mapper = mapper;
    }
    public async Task<RoleDTO> Execute(UpdateRoleDTO dto, CancellationToken ct = default)
    {
        var role = await _roleRepository.Update(dto, ct);
        return _mapper.Map<RoleDTO>(role);
    }
}