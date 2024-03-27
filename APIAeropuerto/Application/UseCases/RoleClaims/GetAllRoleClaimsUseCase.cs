using APIAeropuerto.Application.DTOs.RoleClaims;
using APIAeropuerto.Application.Exceptions.NotFound;
using APIAeropuerto.Domain.Interfaces;
using APIAeropuerto.Persistence.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace APIAeropuerto.Application.UseCases.RoleClaims;

public class GetAllRoleClaimsUseCase : IUseCase<IEnumerable<RoleClaimsDTO>,GetAllRoleClaimsDTO>
{
      private readonly RoleManager<RolePersistence> _roleManager;
        private readonly IMapper _mapper;
        public GetAllRoleClaimsUseCase(RoleManager<RolePersistence> roleManager, IMapper mapper)
        {
            _roleManager = roleManager;
            _mapper = mapper;
        }
        public async Task<IEnumerable<RoleClaimsDTO>> Execute(GetAllRoleClaimsDTO dto, CancellationToken ct = default)
        {
            var role = await _roleManager.FindByIdAsync(dto.Id.ToString());
            if (role is null) throw new NotFoundException("Role not found");
            var claims = await _roleManager.GetClaimsAsync(role);
            return _mapper.Map<IEnumerable<RoleClaimsDTO>>(claims);
        }   
}