using APIAeropuerto.Application.DTOs.Users;
using APIAeropuerto.Application.Exceptions.BadRequest;
using APIAeropuerto.Application.Exceptions.NotFound;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Domain.Interfaces;
using APIAeropuerto.Persistence.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace APIAeropuerto.Persistence.Repositories;

public class UserRepository: IUserRepository
{
    private readonly UserManager<UserPersistence> _userManager;
    private readonly CoreDbContext _context;
    private readonly IMapper _mapper;
    public UserRepository(UserManager<UserPersistence> userManager,CoreDbContext context, IMapper mapper)
    {
        _userManager = userManager;
        _context = context;
        _mapper = mapper;
    }

    public async Task<UsersDTO> CreateUser(CreateUserDTO dto, CancellationToken ct = default)
    {
        var user = UsersEntity.Create(dto.UserName, dto.Email, dto.PasswordHash);
        if (!user.IsSuccess) throw new EmailNotValidBadRequestException(user.ErrorMessage!);
        var userExists = await _userManager.FindByEmailAsync(dto.Email);
        if(userExists is not null) throw new RepeatBadRequestException("User already exists");
        var client = ClientEntity.Create(dto.Name, dto.Nationality, dto.Type);
        if (!client.IsSuccess) throw new Exception(client.ErrorMessage);
        using var transaction = await _context.Database.BeginTransactionAsync(ct);
        try
        {
            var createUserResult = await _userManager.CreateAsync(_mapper.Map<UserPersistence>(user.Value), dto.PasswordHash);
            if (!createUserResult.Succeeded)
            {
                throw new CreateUserBadRequestException(createUserResult.Errors.First().Description);
            }
            var createdUser = await _userManager.FindByEmailAsync(dto.Email);
            if (createdUser == null)
            {
                throw new NotFoundException("Failed to retrieve created user.");
            }
            var clientPersistence = _mapper.Map<ClientPersistence>(client.Value);
            clientPersistence.IdUser = createdUser.Id;
            await _context.Clients.AddAsync(clientPersistence, ct);
            await _context.SaveChangesAsync(ct);
            await transaction.CommitAsync(ct);
            return _mapper.Map<UsersDTO>(user.Value);
        }
        catch (CreateUserBadRequestException e)
        {
            transaction.Rollback();
            throw new CreateUserBadRequestException(e.CustomMessage);
        }
    }

    public async Task<Guid> FindClientByUser(Guid idUser, CancellationToken ct = default)
    {
        var client = await _context.Clients.FirstOrDefaultAsync(x => x.IdUser == idUser, ct);
        if (client is null) throw new NotFoundException("Client not found");
        return client.Id;
    }
}