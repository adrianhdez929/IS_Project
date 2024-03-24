using APIAeropuerto.Application.DTOs.UserClaims;
using APIAeropuerto.Domain.Interfaces;
using APIAeropuerto.Persistence.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace APIAeropuerto.Application.UseCases.UserClaims;

public class GetAllUserClaimsUseCase : IUseCase<IEnumerable<UserClaimsDTO>,GetAllUserClaimsDTO>
{
    private readonly UserManager<UserPersistence> _userManager;
    private readonly IMapper _mapper;
    public GetAllUserClaimsUseCase(UserManager<UserPersistence> userManager, IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }
    public async Task<IEnumerable<UserClaimsDTO>> Execute(GetAllUserClaimsDTO dto, CancellationToken ct = default)
    {
        var user = await _userManager.FindByIdAsync(dto.Id.ToString());
        if (user is null) throw new Exception("User not found");
        var claims = await _userManager.GetClaimsAsync(user);
        return _mapper.Map<IEnumerable<UserClaimsDTO>>(claims);
    }
}