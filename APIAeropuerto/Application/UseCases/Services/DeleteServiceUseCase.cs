using APIAeropuerto.Application.DTOs.Services;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Domain.Interfaces;

namespace APIAeropuerto.Application.UseCases.Services;

public class DeleteServiceUseCase : IUseCase<string,DeleteServiceDTO>
{
    private readonly IServiceRepository _repository;

    public DeleteServiceUseCase(IServiceRepository repository)
    {
        _repository = repository;
    }
    public async Task<string> Execute(DeleteServiceDTO dto, CancellationToken ct = default)
    {
        await _repository.DeleteService(dto.Code);
        return null!;
    }
}