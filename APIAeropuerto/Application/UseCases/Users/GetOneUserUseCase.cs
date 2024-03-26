using APIAeropuerto.Application.DTOs.Users;
using APIAeropuerto.Application.Exceptions.NotFound;
using APIAeropuerto.Domain.Interfaces;
using APIAeropuerto.Persistence.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace APIAeropuerto.Application.UseCases.Users;

public class GetOneUserUseCase : IUseCase<UsersDTO,GetOneUserDTO>
{
    private readonly UserManager<UserPersistence> _userManager;
    private readonly IMapper _mapper;
    public GetOneUserUseCase(UserManager<UserPersistence> userManager, IMapper mapper)
    {
        _userManager = userManager;
        _mapper = mapper;
    }
    public async Task<UsersDTO> Execute(GetOneUserDTO dto, CancellationToken ct = default)
    {
        var user = await _userManager.FindByIdAsync(dto.Id.ToString());
        if (user is null) throw new NotFoundException("User not found");
        return _mapper.Map<UsersDTO>(user);
    }
}