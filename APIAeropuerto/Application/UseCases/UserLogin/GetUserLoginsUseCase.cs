using APIAeropuerto.Application.DTOs.UserLogin;
using APIAeropuerto.Domain.Interfaces;
using APIAeropuerto.Persistence.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace APIAeropuerto.Application.UseCases.UserLogin;

public class GetUserLoginsUseCase : IUseCase<IEnumerable<UserLoginDTO>,GetUserLoginsDTO>
{
    private readonly UserManager<UserPersistence> _userManager;
    private readonly IMapper _mapper;
    public GetUserLoginsUseCase(UserManager<UserPersistence> userManager, IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }
    public async Task<IEnumerable<UserLoginDTO>> Execute(GetUserLoginsDTO dto, CancellationToken ct = default)
    {
        var user = await _userManager.FindByIdAsync(dto.UserId.ToString());
        if (user == null)
        {
            throw new Exception("User not found");
        }
        var userLogins = await _userManager.GetLoginsAsync(user);
        return _mapper.Map<IEnumerable<UserLoginDTO>>(userLogins);
    }
}