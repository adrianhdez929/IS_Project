using APIAeropuerto.Application.DTOs.Client;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Domain.Interfaces;
using APIAeropuerto.Persistence.Entities;
using APIAeropuerto.Persistence.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace APIAeropuerto.Application.UseCases.Client;

public class DeleteClientUseCase : IUseCase<string, DeleteClientDTO>
{
    private readonly IBaseRepository<ClientEntity> _repository;
    private readonly FlightRepository _flightRepository;
    private readonly UserManager<UserPersistence> _userManager;

    public DeleteClientUseCase(IBaseRepository<ClientEntity> repository
    , FlightRepository flightRepository
    , UserManager<UserPersistence> userManager)
    {
        _repository = repository;
        _flightRepository = flightRepository;
        _userManager = userManager;
    }
    public async Task<string> Execute(DeleteClientDTO dto, CancellationToken ct = default)
    {
        var flight = await _flightRepository.GetAllFlights();
        var flightService = flight.Where(x => x.IdClient == dto.Id).ToList();
        if (flightService.Count > 0)
        {
            foreach (var item in flightService)
            {
                await _flightRepository.Delete(item.Id, ct);
            }
        }
        var user = await _userManager.Users.Where(x => x.Client.Id == dto.Id).FirstOrDefaultAsync();
        await _userManager.DeleteAsync(user!);
        return null!;
    }
}