using APIAeropuerto.Application.DTOs.Services;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Domain.Interfaces;

namespace APIAeropuerto.Application.UseCases.Services;

public class DeleteServiceUseCase : IUseCase<string,DeleteServiceDTO>
{
    private readonly IBaseRepository<ServicesEntity> _repository;

    public DeleteServiceUseCase(IBaseRepository<ServicesEntity> repository)
    {
        _repository = repository;
    }
    public async Task<string> Execute(DeleteServiceDTO dto, CancellationToken ct = default)
    {
        await _repository.Delete(dto.Id);
        return null!;
    }
}