using APIAeropuerto.Application.DTOs.Installations;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Domain.Interfaces;
using AutoMapper;

namespace APIAeropuerto.Application.UseCases.Installations;

public class GetAllInstallationUseCase
{
    private readonly IInstallationRepository _repository;
    private readonly IMapper _mapper;

    public GetAllInstallationUseCase(IInstallationRepository repository,IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GetAllInstallationsDTO>> Execute(CancellationToken ct = default)
    {
        var temp = await _repository.GetAllInstallations(ct);
        return _mapper.Map<IEnumerable<GetAllInstallationsDTO>>(temp);
    }
}