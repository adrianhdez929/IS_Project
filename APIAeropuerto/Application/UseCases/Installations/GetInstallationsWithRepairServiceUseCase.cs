using APIAeropuerto.Application.DTOs.Installations;
using APIAeropuerto.Domain.Interfaces;
using AutoMapper;

namespace APIAeropuerto.Application.UseCases.Installations;

public class GetInstallationsWithRepairServiceUseCase
{
    private readonly IInstallationRepository _repository;

    public GetInstallationsWithRepairServiceUseCase(IInstallationRepository repository)
    {
        _repository = repository;
    }
    public async Task<IEnumerable<InstallationDTO>> Execute(CancellationToken ct = default)
    {
        var temp = await _repository.GetAllInstallationsWithRepairServices(ct);
        return temp;
    }
}