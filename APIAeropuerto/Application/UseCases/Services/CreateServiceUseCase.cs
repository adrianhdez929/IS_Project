using APIAeropuerto.Application.DTOs.Services;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Domain.Interfaces;
using APIAeropuerto.Persistence.Entities;
using AutoMapper;

namespace APIAeropuerto.Application.UseCases.Services;

public class CreateServiceUseCase : IUseCase<ServiceDTO,CreateServiceDTO>
{
    private readonly IInstallationRepository _installationRepository;
    private readonly IServiceRepository _repository;
    private readonly IMapper _mapper;

    public CreateServiceUseCase(IInstallationRepository installationRepository,IServiceRepository repository,IMapper mapper)
    {
        _installationRepository = installationRepository;
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<ServiceDTO> Execute(CreateServiceDTO dto, CancellationToken ct = default)
    {
        var i = await _installationRepository.GetOneInstallation(dto.IdInstallation, ct);
        var s = ServicesEntity.Create(dto.Code, dto.Description, dto.Price, i);
        if (!s.IsSuccess) throw new Exception(s.ErrorMessage);
        await _repository.CreateService(_mapper.Map<ServicesPersistence>(s.Value), ct);
        return _mapper.Map<ServiceDTO>(dto);
    }
}