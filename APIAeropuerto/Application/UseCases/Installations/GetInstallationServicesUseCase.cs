using APIAeropuerto.Application.DTOs.Installations;
using APIAeropuerto.Application.DTOs.Services;
using APIAeropuerto.Application.Exceptions.NotFound;
using APIAeropuerto.Domain.Interfaces;
using AutoMapper;

namespace APIAeropuerto.Application.UseCases.Installations;

public class GetInstallationServicesUseCase : IUseCase<GetInstallationServicesDTO,GetOneInstallationDTO>
{
    private readonly IInstallationRepository _repository;

    public GetInstallationServicesUseCase(IInstallationRepository repository,IMapper mapper)
    {
        _repository = repository;
    }
    public async Task<GetInstallationServicesDTO> Execute(GetOneInstallationDTO dto, CancellationToken ct = default)
    {
        var temp = await _repository.GetServices(dto.Id, ct);
        if (temp is null) throw new NotFoundException("Services not Exists");
        return temp;
    }
}