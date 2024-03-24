using APIAeropuerto.Application.DTOs.Users;
using APIAeropuerto.Domain.Interfaces;
using APIAeropuerto.Persistence.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace APIAeropuerto.Application.UseCases.Users;

public class UpdateUserUseCase : IUseCase<UsersDTO,UpdateUserDTO>
{
    private readonly UserManager<UserPersistence> _userManager;
    private readonly IMapper _mapper;
    public UpdateUserUseCase(UserManager<UserPersistence> userManager, IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }
    public async Task<UsersDTO> Execute(UpdateUserDTO dto, CancellationToken ct = default)
    {
        var user = await _userManager.FindByIdAsync(dto.Id.ToString());
        if (user is null) throw new Exception("User not found");
        user.Email = dto.Email;
        user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, dto.Password);
        var result = await _userManager.UpdateAsync(user);
        if (result.Succeeded) return _mapper.Map<UsersDTO>(user);
        return null!;
    }
}