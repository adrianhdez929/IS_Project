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
    private readonly IUserRepository _repository;
    public CreateUserUseCase(IUserRepository repository)
    {
        _repository = repository;
    }
    public async Task<UsersDTO> Execute(CreateUserDTO dto, CancellationToken ct = default)
    {
        
        return await _repository.CreateUser(dto,ct);
    }
}