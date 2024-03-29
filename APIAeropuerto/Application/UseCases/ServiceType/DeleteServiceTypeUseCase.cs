using APIAeropuerto.Application.DTOs.ServiceType;
using APIAeropuerto.Application.Exceptions.NotFound;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Domain.Interfaces;

namespace APIAeropuerto.Application.UseCases.ServiceType;

public class DeleteServiceTypeUseCase : IUseCase<string,DeleteServiceTypeDTO>
{
    private readonly IBaseRepository<ServiceTypeEntity> _repository;
    
    public DeleteServiceTypeUseCase(IBaseRepository<ServiceTypeEntity> repository)
    {
        _repository = repository;
    }
    public async Task<string> Execute(DeleteServiceTypeDTO dto, CancellationToken ct = default)
    {
        await _repository.Delete(dto.Id, ct);
        return "Service Type deleted successfully";
    }
}