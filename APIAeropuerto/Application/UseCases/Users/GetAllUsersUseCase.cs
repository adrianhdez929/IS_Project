using APIAeropuerto.Application.DTOs.Users;
using APIAeropuerto.Persistence.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace APIAeropuerto.Application.UseCases.Users;

public class GetAllUsersUseCase
{
    private readonly UserManager<UserPersistence> _userManager;
    private readonly IMapper _mapper;
    public GetAllUsersUseCase(UserManager<UserPersistence> userManager, IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }
    public async Task<IEnumerable<UsersDTO>> Execute(CancellationToken ct = default)
    {
        var users = await _userManager.Users.ToListAsync();
        return _mapper.Map<IEnumerable<UsersDTO>>(users);
    }
}