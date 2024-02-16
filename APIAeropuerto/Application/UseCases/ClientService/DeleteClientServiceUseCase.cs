using APIAeropuerto.Application.DTOs.ClientService;
using APIAeropuerto.Domain.Interfaces;

namespace APIAeropuerto.Application.UseCases.ClientService;

public class DeleteClientServiceUseCase : IUseCase<string , DeleteClientServiceDTO>
{
    private readonly IClientServiceRepository _repository;

    public DeleteClientServiceUseCase(IClientServiceRepository repository)
    {
        _repository = repository;
    }
    public async Task<string> Execute(DeleteClientServiceDTO dto, CancellationToken ct = default)
    {
        await _repository.DeleteClientService(dto, ct);
        return null!;
    }
}