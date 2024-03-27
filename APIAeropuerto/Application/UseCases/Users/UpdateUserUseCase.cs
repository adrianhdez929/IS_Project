using APIAeropuerto.Application.DTOs.Users;
using APIAeropuerto.Application.Exceptions.BadRequest;
using APIAeropuerto.Application.Exceptions.NotFound;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Domain.Interfaces;
using APIAeropuerto.Domain.Shared;
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
        if (user is null) throw new NotFoundException("User not found");
        var wrapper = UsersEntity.CheckEmail(dto.Email);
        if(!wrapper.IsSuccess) throw new EmailNotValidBadRequestException(wrapper.ErrorMessage!);
        user.Email = dto.Email;
        var passwordChecked = CheckPassword.Check(dto.Password);
        if(!String.IsNullOrEmpty(passwordChecked)) throw new PasswordBadRequestException(passwordChecked);
        var d = _userManager.PasswordHasher.HashPassword(user, dto.Password);
        user.PasswordHash = d;
        var result = await _userManager.UpdateAsync(user);
        if (result.Succeeded) return _mapper.Map<UsersDTO>(user);
        return null!;
    }
}