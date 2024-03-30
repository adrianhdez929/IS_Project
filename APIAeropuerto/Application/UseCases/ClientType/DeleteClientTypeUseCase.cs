using APIAeropuerto.Application.DTOs.ClientType;
using APIAeropuerto.Application.DTOs.InstallationType;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Domain.Interfaces;

namespace APIAeropuerto.Application.UseCases.ClientType;

public class DeleteClientTypeUseCase : IUseCase<string,DeleteClientTypeDTO>
{
    private readonly IBaseRepository<ClientTypeEntity> _repository;
    
    public DeleteClientTypeUseCase(IBaseRepository<ClientTypeEntity> repository)
    {
        _repository = repository;
    }
    public async Task<string> Execute(DeleteClientTypeDTO dto, CancellationToken ct = default)
    {
        await _repository.Delete(dto.Id, ct);
        return "Client Type deleted successfully";
    }
}