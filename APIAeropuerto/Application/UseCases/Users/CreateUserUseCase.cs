using APIAeropuerto.Application.DTOs.Users;
using APIAeropuerto.Application.Exceptions.BadRequest;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Domain.Interfaces;
using APIAeropuerto.Persistence.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace APIAeropuerto.Application.UseCases.Users;

public class CreateUserUseCase : IUseCase<UsersDTO,CreateUserDTO>
{
    private readonly UserManager<UserPersistence> _userManager;
    private readonly IMapper _mapper;
    public CreateUserUseCase(UserManager<UserPersistence> userManager, IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }
    public async Task<UsersDTO> Execute(CreateUserDTO dto, CancellationToken ct = default)
    {
        var user = UsersEntity.Create(dto.UserName, dto.Email, dto.PasswordHash);
        if (!user.IsSuccess) throw new EmailNotValidBadRequestException(user.ErrorMessage!);
        var userExists = await _userManager.FindByEmailAsync(dto.Email);
        if(userExists is not null) throw new RepeatBadRequestException("User already exists");
        var result = _userManager.CreateAsync(_mapper.Map<UserPersistence>(user.Value), dto.PasswordHash).Result;
        if (!result.Succeeded) throw new Exception(result.Errors.First().Description);
        return _mapper.Map<UsersDTO>(user.Value);
    }
}