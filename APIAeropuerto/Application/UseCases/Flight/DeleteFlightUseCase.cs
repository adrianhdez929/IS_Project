using APIAeropuerto.Application.DTOs.Flight;
using APIAeropuerto.Application.Exceptions.NotFound;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Domain.Interfaces;

namespace APIAeropuerto.Application.UseCases.Flight;

public class DeleteFlightUseCase : IUseCase<string, DeleteFlightDTO>
{
    private readonly IBaseRepository<FlightEntity> _repository;
    
    public DeleteFlightUseCase(IBaseRepository<FlightEntity> repository)
    {
        _repository = repository;
    }
    public async Task<string> Execute(DeleteFlightDTO dto, CancellationToken ct = default)
    {
        var flight = await _repository.GetOne(dto.Id, ct);
        if (flight is null)
            throw new NotFoundException("Flight not found");
        await _repository.Delete(dto.Id, ct);
        return "Flight deleted";
    }
}