using APIAeropuerto.Application.DTOs.Users;
using APIAeropuerto.Domain.Interfaces;
using APIAeropuerto.Persistence.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace APIAeropuerto.Application.UseCases.Users;

public class DeleteUserUseCase : IUseCase<string,DeleteUserDTO>
{
    private readonly UserManager<UserPersistence> _userManager;
    public DeleteUserUseCase(UserManager<UserPersistence> userManager)
    {
        _userManager = userManager;
    }
    public async Task<string> Execute(DeleteUserDTO dto, CancellationToken ct = default)
    {
        var user = await _userManager.FindByIdAsync(dto.Id.ToString());
        if (user is null) throw new Exception("User not found"); 
        var result = _userManager.DeleteAsync(user).Result;
        if (result.Succeeded) return"User deleted";
        return "Error deleting user";
    }
}