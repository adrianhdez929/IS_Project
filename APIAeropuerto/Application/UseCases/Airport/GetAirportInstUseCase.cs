using APIAeropuerto.Application.DTOs.Airport;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Domain.Interfaces;
using AutoMapper;

namespace APIAeropuerto.Application.UseCases.Airport;

public class GetAirportInstUseCase : IUseCase<GetAirportInstDTO,GetOneAirportDTO>
{
    private readonly IAirportRepository _repository;
    public GetAirportInstUseCase(IAirportRepository repository,IMapper mapper)
    {
        _repository = repository;
    }
    public async Task<GetAirportInstDTO> Execute(GetOneAirportDTO dto, CancellationToken ct = default)
    {
        var a = await _repository.GetInstallations(dto.Id, ct);
        if (a is null) throw new Exception("Installations not Exists");
        return a;
    }
}