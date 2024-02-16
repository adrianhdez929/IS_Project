using APIAeropuerto.Application.DTOs.Installations;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Domain.Interfaces;

namespace APIAeropuerto.Application.UseCases.Installations;

public class DeleteInstallationUseCase : IUseCase<string, DeleteInstallationDTO>
{
    private readonly IBaseRepository<InstallationsEntity> _repository;

    public DeleteInstallationUseCase(IBaseRepository<InstallationsEntity> repository)
    {
        _repository = repository;
    }
    public async Task<string> Execute(DeleteInstallationDTO dto, CancellationToken ct = default)
    {
        await _repository.Delete(dto.Id);
        return null!;
    }
}