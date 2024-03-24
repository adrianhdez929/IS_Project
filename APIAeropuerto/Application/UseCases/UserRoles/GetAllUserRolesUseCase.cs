using APIAeropuerto.Application.DTOs.UserRoles;
using APIAeropuerto.Domain.Interfaces;
using APIAeropuerto.Persistence.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace APIAeropuerto.Application.UseCases.UserRoles;

public class GetAllUserRolesUseCase : IUseCase<IEnumerable<UserRolesDTO>,GetAllUserRolesDTO>
{
    private readonly UserManager<UserPersistence> _userManager;
    private readonly IMapper _mapper;
    public GetAllUserRolesUseCase(UserManager<UserPersistence> userManager, IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }
    public async Task<IEnumerable<UserRolesDTO>> Execute(GetAllUserRolesDTO dto, CancellationToken ct = default)
    {
        var user = await _userManager.FindByIdAsync(dto.Id.ToString());
        if (user is null) throw new Exception("User not found");
        var roles = await _userManager.GetRolesAsync(user);
        return _mapper.Map<IEnumerable<UserRolesDTO>>(roles);
    }
}