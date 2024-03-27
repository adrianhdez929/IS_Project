using APIAeropuerto.Application.DTOs.UserLogin;
using APIAeropuerto.Application.Exceptions.NotFound;
using APIAeropuerto.Domain.Interfaces;
using APIAeropuerto.Persistence.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace APIAeropuerto.Application.UseCases.UserLogin;

public class GetUserLoginsUseCase : IUseCase<IEnumerable<GetUserLoginsDTO>,GetUserLoginsDTO>
{
    private readonly UserManager<UserPersistence> _userManager;
    private readonly IMapper _mapper;
    public GetUserLoginsUseCase(UserManager<UserPersistence> userManager, IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }
    public async Task<IEnumerable<GetUserLoginsDTO>> Execute(GetUserLoginsDTO dto, CancellationToken ct = default)
    {
        var user = await _userManager.FindByIdAsync(dto.UserId.ToString());
        if (user == null)
        {
            throw new NotFoundException("User not found");
        }
        var userLogins = await _userManager.GetLoginsAsync(user);
        return _mapper.Map<IEnumerable<GetUserLoginsDTO>>(userLogins);
    }
}