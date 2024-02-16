using APIAeropuerto.Application.DTOs.Installations;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Domain.Interfaces;
using AutoMapper;

namespace APIAeropuerto.Application.UseCases.Installations;

public class GetAllInstallationUseCase
{
    private readonly IBaseRepository<InstallationsEntity> _repository;
    private readonly IMapper _mapper;

    public GetAllInstallationUseCase(IBaseRepository<InstallationsEntity> repository,IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<InstallationDTO>> Execute(CancellationToken ct = default)
    {
        var temp = await _repository.GetAll(ct);
        return _mapper.Map<IEnumerable<InstallationDTO>>(temp);
    }
}