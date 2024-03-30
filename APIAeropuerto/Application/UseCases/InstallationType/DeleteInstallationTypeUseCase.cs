using APIAeropuerto.Application.DTOs.InstallationType;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Domain.Interfaces;

namespace APIAeropuerto.Application.UseCases.InstallationType;

public class DeleteInstallationTypeUseCase : IUseCase<string,DeleteInstallationTypeDTO>
{
    private readonly IBaseRepository<InstallationTypeEntity> _repository;
    
    public DeleteInstallationTypeUseCase(IBaseRepository<InstallationTypeEntity> repository)
    {
        _repository = repository;
    }
    public async Task<string> Execute(DeleteInstallationTypeDTO dto, CancellationToken ct = default)
    {
        await _repository.Delete(dto.Id, ct);
        return "Installation Type deleted successfully";
    }
}