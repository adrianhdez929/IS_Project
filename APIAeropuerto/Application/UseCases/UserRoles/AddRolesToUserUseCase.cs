using APIAeropuerto.Application.DTOs.UserRoles;
using APIAeropuerto.Domain.Interfaces;

namespace APIAeropuerto.Application.UseCases.UserRoles;

public class AddRolesToUserUseCase : IUseCase<string,AddRolesToUserDTO>
{
    private readonly IRoleRepository _roleRepository;
    
    public AddRolesToUserUseCase(IRoleRepository roleRepository)
    {
        _roleRepository = roleRepository;
    }
    public async Task<string> Execute(AddRolesToUserDTO dto, CancellationToken ct = default)
    {
        return await _roleRepository.AddRolesToUser(dto, ct);
    }
}