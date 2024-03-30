using APIAeropuerto.Application.DTOs.Users;
using APIAeropuerto.Application.Exceptions.NotFound;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Domain.Interfaces;
using APIAeropuerto.Persistence.Entities;
using APIAeropuerto.Persistence.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace APIAeropuerto.Application.UseCases.Users;

public class DeleteUserUseCase : IUseCase<string,DeleteUserDTO>
{
    private readonly UserManager<UserPersistence> _userManager;
    private readonly FlightRepository _flightRepository;
    private readonly IBaseRepository<ClientEntity> _clientRepository;
    public DeleteUserUseCase(UserManager<UserPersistence> userManager
    , FlightRepository flightRepository
    , IBaseRepository<ClientEntity> clientRepository)
    {
        _userManager = userManager;
        _flightRepository = flightRepository;
        _clientRepository = clientRepository;
    }
    public async Task<string> Execute(DeleteUserDTO dto, CancellationToken ct = default)
    {
        var user = await _userManager.FindByIdAsync(dto.Id.ToString());
        if (user is null) throw new NotFoundException("User not found");
        var flight = await _flightRepository.GetAllFlights();
        var client = await _clientRepository.GetAll(ct);
        var clientService = client.Where(x => x.IdUser == dto.Id).FirstOrDefault();
        var flightService = flight.Where(x => x.IdClient == clientService!.Id).ToList();
        if (flightService.Count > 0)
        {
            foreach (var item in flightService)
            {
                await _flightRepository.Delete(item.Id, ct);
            }
        }
        var result = _userManager.DeleteAsync(user).Result;
        if (result.Succeeded) return"User deleted";
        return "Error deleting user";
    }
}