using APIAeropuerto.Application.DTOs.Services;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Domain.Interfaces;
using APIAeropuerto.Persistence.Repositories;

namespace APIAeropuerto.Application.UseCases.Services;

public class DeleteServiceUseCase : IUseCase<string,DeleteServiceDTO>
{
    private readonly IBaseRepository<ServicesEntity> _repository;
    private readonly RepairRepository _repairRepository;

    public DeleteServiceUseCase(IBaseRepository<ServicesEntity> repository
    , RepairRepository repairRepository)
    {
        _repository = repository;
        _repairRepository = repairRepository;
    }
    public async Task<string> Execute(DeleteServiceDTO dto, CancellationToken ct = default)
    {
        var repair = await _repairRepository.GetAllRepairs();
        var repairService = repair.Where(x=>x.IdService == dto.Id).ToList();
        if (repairService.Count > 0)
        {
            foreach (var item in repairService)
            {
                await _repairRepository.Delete(item.Id,ct);
            }
        }
        await _repository.Delete(dto.Id,ct);
        return null!;
    }
}