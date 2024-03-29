using APIAeropuerto.Application.DTOs.Services;
using APIAeropuerto.Application.Exceptions.NotFound;
using APIAeropuerto.Domain.Entities;
using APIAeropuerto.Domain.Interfaces;
using APIAeropuerto.Persistence.Repositories;
using AutoMapper;

namespace APIAeropuerto.Application.UseCases.Services;

public class UpdateServiceUseCase : IUseCase<ServiceDTO,UpdateServiceDTO>
{
    private readonly IServiceRepository _repository;
    private readonly IInstallationRepository _installationRepository;
    private readonly ServiceTypeRepository _serviceTypeRepository;
    private readonly IMapper _mapper;

    public UpdateServiceUseCase(IServiceRepository repository,
        IInstallationRepository installationRepository,
        ServiceTypeRepository serviceTypeRepository,
        IMapper mapper)
    {
        _repository = repository;
        _installationRepository = installationRepository;
        _serviceTypeRepository = serviceTypeRepository;
        _mapper = mapper;
    }
    public async Task<ServiceDTO> Execute(UpdateServiceDTO dto, CancellationToken ct = default)
    {
        var i = await _installationRepository.GetOneInstallation(dto.IdInstallation, ct);
        if (i is null) throw new NotFoundException("Installation not found");
        var st = await _serviceTypeRepository.GetOneServiceType(dto.IdServiceType,ct);
        if (st is null) throw new NotFoundException("Service type not found");
        var temp = await _repository.GetOneService(dto.Id);
        temp.Update(dto.Code,dto.Description,dto.Precio, i, st);
        await _repository.UpdateService(dto.Id,temp, ct);
        return _mapper.Map<ServiceDTO>(temp);
    }
}