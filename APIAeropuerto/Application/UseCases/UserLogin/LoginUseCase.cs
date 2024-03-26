using APIAeropuerto.Application.DTOs.UserLogin;
using APIAeropuerto.Application.Exceptions.BadRequest;
using APIAeropuerto.Application.Exceptions.NotFound;
using APIAeropuerto.Application.UseCases.Token;
using APIAeropuerto.Domain.Interfaces;
using APIAeropuerto.Persistence.Entities;
using Microsoft.AspNetCore.Identity;

namespace APIAeropuerto.Application.UseCases.UserLogin;

public class LoginUseCase : IUseCase<UserLoginDTO,CredentialModelDTO>
{
    private readonly UserManager<UserPersistence> _userManager;
    private readonly SignInManager<UserPersistence> _signInManager;
    private readonly CreateTokenUseCase _createTokenUseCase;
    public LoginUseCase(UserManager<UserPersistence> userManager, SignInManager<UserPersistence> signInManager, CreateTokenUseCase createTokenUseCase)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _createTokenUseCase = createTokenUseCase;
    }
    public async Task<UserLoginDTO> Execute(CredentialModelDTO dto, CancellationToken ct = default)
    {
        var user = await _userManager.FindByEmailAsync(dto.Email);
        if (user is null) throw new NotFoundException("User not found");
        var result = await _signInManager.PasswordSignInAsync(user, dto.Password, false, false);
        if (!result.Succeeded) throw new InvalidCredentialBadRequestException("Invalid credentials");
        var token = await _createTokenUseCase.Execute(user);
        if (token is null) throw new CreatingTokenBadRequestException("Error creating token");
        return new UserLoginDTO
        {
            Id = user.Id,
            Token = token
        };
    }
}