using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using APIAeropuerto.Application.DTOs.Users;
using APIAeropuerto.Application.Exceptions.BadRequest;
using APIAeropuerto.Application.Exceptions.NotFound;
using APIAeropuerto.Persistence.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace APIAeropuerto.Application.UseCases.Token;

public class CreateTokenUseCase 
{
    private readonly UserManager<UserPersistence> _userManager;
    private readonly IConfiguration _configuration;
    public CreateTokenUseCase(UserManager<UserPersistence> userManager, IConfiguration configuration)
    {
        _userManager = userManager;
        _configuration = configuration;
    }
    public async Task<string> Execute(UserPersistence dto, CancellationToken ct = default)
    {
        var user = await _userManager.FindByIdAsync(dto.Id.ToString());
        if (user is null) throw new NotFoundException("User not found");
        var userClaims = await _userManager.GetClaimsAsync(user);
        var roles = await _userManager.GetRolesAsync(user);
        var userRoles = roles.Select(r => new Claim(ClaimTypes.Role, r)).ToList();
        var identityClaims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };
        var claims = new List<Claim>();
        claims.AddRange(userClaims);
        claims.AddRange(userRoles);
        claims.AddRange(identityClaims);
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT_Key"]!));
        //key utilizar security algorithm para key de 10 bits
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            _configuration["JWT_Issuer"],
            _configuration["JWT_Audience"],
            claims,
            expires: DateTime.Now.AddMinutes(60),
            signingCredentials: credentials
        );
        user.LastLogin = DateTime.Now;
        var result = await _userManager.UpdateAsync(user);
        if (!result.Succeeded) throw new UpdateUserBadRequestException("Error on update user");
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}