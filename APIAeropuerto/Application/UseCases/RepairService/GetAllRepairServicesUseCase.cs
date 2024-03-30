using APIAeropuerto.Application.DTOs.Services;
using APIAeropuerto.Domain.Interfaces;

namespace APIAeropuerto.Application.UseCases.RepairService;

public class GetAllRepairServicesUseCase
{
    private readonly IServiceRepository _repository;

    public GetAllRepairServicesUseCase(IServiceRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<GetAllServicesDTO>> Execute(CancellationToken ct = default)
    {
        return await _repository.GetAllRepairServices(ct);
    }
}