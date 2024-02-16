using APIAeropuerto.Application.DTOs.Airport;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Domain.Interfaces;
using AutoMapper;

namespace APIAeropuerto.Application.UseCases.Airport;

public class DeleteAirportUseCase:IUseCase<string,DeleteAirportDTO>
{
    private readonly IBaseRepository<AirportEntity> _repository;

    public DeleteAirportUseCase(IBaseRepository<AirportEntity> repository, IMapper mapper)
    {
        _repository = repository;
    }
    public async Task<string> Execute(DeleteAirportDTO dto, CancellationToken ct = default)
    {
        await _repository.Delete(dto.Id);
        return null!;
    }
}